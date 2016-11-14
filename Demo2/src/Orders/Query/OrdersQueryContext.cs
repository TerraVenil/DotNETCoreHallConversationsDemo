using System;
using System.Linq;
using Demo2.Entities;
using Demo2.Infrastructure;

namespace Demo2.Orders.Query
{
    public class OrdersQueryContext : IOrdersQueryContext
    {
        private readonly RemontOnlineDbContext _remontOnlineDbContext;

        public OrdersQueryContext(RemontOnlineDbContext remontOnlineDbContext)
        {
            if (remontOnlineDbContext == null)
                throw new ArgumentNullException(nameof(remontOnlineDbContext));

            _remontOnlineDbContext = remontOnlineDbContext;
        }

        public IQueryable<Order> Orders => _remontOnlineDbContext.Orders;
    }
}