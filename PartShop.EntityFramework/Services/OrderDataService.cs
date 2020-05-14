using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace PartShop.EntityFramework.Services
{
    public class OrderDataService : IOrderService
    {

        private readonly CarPartDbContextFactory _contextFactory;

        public OrderDataService(CarPartDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        //ДОПИСАТЬ УМЕНЬШЕНИЕ АССОРТИМЕСТА В PARTPROVIDERS
        public async Task<double> CreateOrder(Account account, List<PartFullInfo> partInCar)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
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
                    Status = OrderStatus.CREATED
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
                return price;
            }
        }
    }
}
