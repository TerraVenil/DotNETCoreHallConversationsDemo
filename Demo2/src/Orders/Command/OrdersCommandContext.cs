using System;
using System.Threading.Tasks;
using Demo2.Entities;
using Demo2.Infrastructure;

namespace Demo2.Orders.Command
{
    public class OrdersCommandContext : IOrdersCommandContext
    {
        private readonly RemontOnlineDbContext _remontOnlineDbContext;

        public OrdersCommandContext(RemontOnlineDbContext remontOnlineDbContext)
        {
            if (remontOnlineDbContext == null)
                throw new ArgumentNullException(nameof(remontOnlineDbContext));

            _remontOnlineDbContext = remontOnlineDbContext;
        }

        public async Task CreateOrder(Order order)
        {
            _remontOnlineDbContext.Orders.Add(order);
            await _remontOnlineDbContext.SaveChangesAsync();
        }
    }
}