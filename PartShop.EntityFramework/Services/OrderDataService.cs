using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartShop.Domain.Model;
using PartShop.Domain.Services;
using PartShop.EntityFramework.Services.Common;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace PartShop.EntityFramework.Services
{
    public class OrderDataService : IOrderService
    {
        private readonly CarPartDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Order> _nonQueryDataService;
        private readonly IAccountService _accountService;

        public OrderDataService(CarPartDbContextFactory contextFactory, IAccountService accountService)
        {
            _contextFactory = contextFactory;
            _accountService = accountService;
            _nonQueryDataService = new NonQueryDataService<Order>(contextFactory);
        }
        public async Task<double> CreateOrder(Account account, List<PartFullInfo> partInCar, Address address)
        {

            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                if(partInCar.Count()==0) throw new Exception("Вы выбрали 0 деталей для звказа");

                var results = new List<ValidationResult>();
                var addrContext = new ValidationContext(address);

                StringBuilder errorResult = new StringBuilder();

                if (!Validator.TryValidateObject(address, addrContext, results, true))
                {
                    foreach (var error in results)
                    {
                        errorResult.Append(error.ErrorMessage + '\n');
                    }
                    throw new Exception(errorResult.ToString());
                }

                StringBuilder idParts=new StringBuilder();
                double price = 0;
                Order order = new Order()
                {
                    Address =address,
                    OrderCreationTime = DateTime.Now,
                    Status = OrderStatus.CREATED
                };
                List<OrderParts> orderParts=new List<OrderParts>();

                foreach (var p in partInCar)
                {
                    PartProvider pp = context.PartProviders.FirstOrDefault(x => x.PartId == p.PartId && x.ProviderId == p.ProviderId);//acc check
                    if (pp.TotalParts < p.ProviderPartAmount)
                    {
                        idParts.Append(pp.PartId.ToString()+' ');
                    }
                }

                if(idParts.Length!=0) throw new Exception($"Данного числа запчастей нет на складе.\nId: {idParts}\n О поступлении мы вам cообщим по e-mail");

                foreach (var p in partInCar)
                {
                    orderParts.Add(new OrderParts()
                    {
                        AmountPart = p.ProviderPartAmount,
                        OrderId = order.Id,
                        PartId = p.PartId,
                        Price = p.ProviderPartPrice,
                        ProviderId = p.ProviderId
                    });
                    price += p.ProviderPartPrice * p.ProviderPartAmount;
                    PartProvider pp=context.PartProviders.FirstOrDefault(x => x.PartId == p.PartId && x.ProviderId == p.ProviderId);//acc check
                    

                    if (pp != null && (pp.TotalParts > p.ProviderPartAmount))
                    {
                        pp.TotalParts -= p.ProviderPartAmount;
                        context.PartProviders.Update(pp);
                    }
                    

                }

                if (price > account.Balance) throw new Exception("Недостаточно денег для заказа");
                order.Parts = orderParts;
                account.Balance -= price;
                order.Status = OrderStatus.PAYED;
                account.Orders.Add(order);
                context.Accounts.Update(account);
                await context.SaveChangesAsync();

                //await SendEmail(order, "Магазин автозапчастей: оплата заказа", $"Ваш заказ с номером {order.Id} был оплачен");
                
                return price;
            }
        }

        public async Task<bool> PrintCheck(Order order, string path)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                if (order == null) throw new Exception("Вы не выбрали заказ");

                Address address = await context.Address.FirstOrDefaultAsync(x => x.Id == order.Id);
                order.Address = address;
                var orderParts = await context.Orders.Where(a => a.Id == order.Id)
                    .Join(context.OrderParts,
                        t => t.Id,
                        x => x.OrderId,
                        (t, x) => new { t, x })
                    .Join(context.Parts,
                        l => l.x.PartId,
                        k => k.Id,
                        (l, k) => new { l, k })
                    .Join(context.PartProviders,
                        d => d.l.x.PartId,
                        m => m.PartId,
                        (d, m) => new { d, m })
                    .Join(context.Providers,
                        z => z.m.ProviderId,
                        u => u.Id,
                        (z, u) => new
                        {
                            PartId = z.d.k.Id,
                            PartName = z.d.k.Name,
                            PartColor = z.d.k.Color,
                            PartDescription = z.d.k.Description,
                            PartInOrder = z.d.l.x.AmountPart,
                            PartPrice = z.d.l.x.Price,
                            PartProvider=z.m.ProviderId,
                            Provider = u.Name
                        }
                        ).ToListAsync();


                using (PdfDocument document = new PdfDocument())
                {
                    double price = 0;
                    //Add a page to the document
                    PdfPage page = document.Pages.Add();
                    PdfGraphics graphics = page.Graphics;
                    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                    PdfFont mainFont = new PdfStandardFont(PdfFontFamily.Helvetica, 14);

                    //Draw the text
                    graphics.DrawString("Part shop check", font, PdfBrushes.Black, new PointF(200, 0));
                    graphics.DrawString($"Order id:{order.Id}", mainFont, PdfBrushes.Black, new PointF(0, 25));
                    graphics.DrawString($"Creation date:{order.OrderCreationTime}", mainFont, PdfBrushes.Black, new PointF(0, 40));
                    graphics.DrawString($"Finish date:{order.FinishDate}", mainFont, PdfBrushes.Black, new PointF(0, 55));
                    graphics.DrawString($"Status:{order.Status}", mainFont, PdfBrushes.Black, new PointF(0, 70));
                    graphics.DrawString($"Address: {order.Address.City} city, {order.Address.Street} street, {order.Address.House}-{order.Address.Apartament}", mainFont, PdfBrushes.Black, new PointF(0, 85));


                    PdfGrid pdfGrid = new PdfGrid();
                    DataTable dataTable = new DataTable();

                    dataTable.Columns.Add("Id");
                    dataTable.Columns.Add("Name");
                    dataTable.Columns.Add("Color");
                    dataTable.Columns.Add("Description");
                    dataTable.Columns.Add("Provider");
                    dataTable.Columns.Add("Amount");
                    dataTable.Columns.Add("Price by part unit");

                    foreach (var p in orderParts)
                    {
                        dataTable.Rows.Add(new object[]{p.PartId,p.PartName, p.PartColor, p.PartDescription, p.Provider, p.PartInOrder, p.PartPrice});
                        price += p.PartInOrder * p.PartPrice;
                    }

                    graphics.DrawString($"Total price:{price}", mainFont, PdfBrushes.Black, new PointF(0, 105));

                    pdfGrid.DataSource = dataTable;
                    pdfGrid.Draw(page, new PointF(0, 120));

                    document.Save(path);
                    document.Close(true);
                }

                return true;
            }
        }

        //переелать
        public async Task<bool> CancelOrder(Account account,Order order)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                if (order == null) throw new Exception("Вы не выбрали заказ");

                if (order.Status == OrderStatus.FINISHED||order.Status==OrderStatus.DELIVERED) return false;
                Order selectedOrder = await Get(order.Id);
                double price = 0;
                order.Status = OrderStatus.CANCELLED;
                foreach (var p in selectedOrder.Parts)
                {
                    price += p.AmountPart * p.Price;
                    PartProvider pp = await context.PartProviders.FirstOrDefaultAsync(x =>
                        x.PartId == p.PartId && x.ProviderId == p.ProviderId);

                    pp.TotalParts += p.AmountPart;
                }
                //отправить письмо
                
                account.Balance += price;
                context.Accounts.Update(account);
                //await SendEmail(order, "Магазин автозапчастей: изменение статуса заказа", $"Ваш заказ с номером {order.Id} был отменён");
                context.Orders.Update(order);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> FinishOrder(Order order)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                if (order == null) throw new Exception("Вы не выбрали заказ");
                //отправить письмо
                if (order.Status != OrderStatus.DELIVERED) throw new Exception("Заказ не доставлен");
                order.Status = OrderStatus.FINISHED;
                order.FinishDate=DateTime.Now;
                //await SendEmail(order, "Магазин автозапчастей: изменение статуса заказа", $"Ваш заказ с номером {order.Id} завершён");
                context.Orders.Update(order);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> DelivOrder(Order order)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                if (order == null) throw new Exception("Вы не выбрали заказ");
                if (order.Status != OrderStatus.PAYED) throw new Exception("Заказ не оплачен");
                order.Status = OrderStatus.DELIVERED;
                //await SendEmail(order, "Магазин автозапчастей: статуса заказа", $"Ваш заказ с номером {order.Id} был отправлен");
                context.Orders.Update(order);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Order> entity = await context.Orders
                    .Include(a => a.Address)
                    .Include(b => b.Parts)
                    .ToListAsync();

                return entity;
            }
        }

        public async Task<Order> Get(int id)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                Order entity = await context.Orders
                    .Include(a => a.Address)
                    .Include(b => b.Parts)
                    .FirstOrDefaultAsync(x=>x.Id==id);
                if(entity==null) throw new Exception("Вы не выбрали заказ");
                return entity;
            }
        }

        public async Task<Order> Create(Order entity)
        {
            return await _nonQueryDataService.Create(entity);
        }
        public async Task<Order> Update(int id, Order entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

    }
}