using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        public OrderDataService(CarPartDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Order>(contextFactory);
        }
        //ДОПИСАТЬ УМЕНЬШЕНИЕ АССОРТИМЕСТА В PARTPROVIDERS И ИЗМЕНЕНИЕ АДРЕСА
        public async Task<double> CreateOrder(Account account, List<PartFullInfo> partInCar)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                await PrintCheck(3);
                double price = 0;
                Order order = new Order()
                {
                    Address = new Address()
                    {
                        Apartament = 1,
                        City = "dsad",
                        House = 1,
                        Street = "das"
                    },
                    OrderCreationTime = DateTime.Now,
                };

                List<OrderParts> orderParts=new List<OrderParts>();

                foreach (var p in partInCar)
                {
                    orderParts.Add(new OrderParts()
                    {
                        AmountPart = p.ProviderPartAmount,
                        OrderId = order.Id,
                        PartId = p.PartId,
                        Price = p.ProviderPartPrice
                    });
                    price += p.ProviderPartPrice * p.ProviderPartAmount;
                    PartProvider pp=context.PartProviders.FirstOrDefault(x => x.PartId == p.PartId && x.ProviderId == p.ProviderId);
                    //Проверка на количество

                    if(pp!=null&&pp.TotalParts<p.ProviderPartAmount) pp.TotalParts -= p.ProviderPartAmount;
                }

                if (price > account.Balance) return 0;
                order.Parts = orderParts;
                account.Balance -= price;
                order.Status = OrderStatus.PAYED;
                account.Orders.Add(order);
                context.Accounts.Update(account);
                await context.SaveChangesAsync();
                await PrintCheck(3);
                return price;
            }
        }

        public async Task<bool> PrintCheck(int orderId)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                Order order = await Get(orderId);
                var orderParts = await context.Orders.Where(a => a.Id == orderId)
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
                    graphics.DrawString($"Address: {order.Address.City}, {order.Address.Street} street, {order.Address.House}-{order.Address.Apartament}", mainFont, PdfBrushes.Black, new PointF(0, 85));


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

                    //как самому выбрать путь?
                    document.Save("Output.pdf");
                    document.Close(true);
                }

                return true;
            }
        }

        public async Task<bool> CancelOrder(Order order)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                order.Status = OrderStatus.CANCELLED;
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