using System;
using System.Linq;
using Demo2.Entities;
using Demo2.Infrastructure;

namespace Demo2.Orders.Query
{
    public class OrderStatusesQueryContext : IOrderStatusesQueryContext
    {
        private readonly RemontOnlineDbContext _remontOnlineDbContext;

        public OrderStatusesQueryContext(RemontOnlineDbContext remontOnlineDbContext)
        {
          if (remontOnlineDbContext == null)
                throw new ArgumentNullException(nameof(remontOnlineDbContext));

            _remontOnlineDbContext = remontOnlineDbContext;
        }

        public IQueryable<OrderStatus> OrderStatuses => _remontOnlineDbContext.OrderStatuses;
    }
}