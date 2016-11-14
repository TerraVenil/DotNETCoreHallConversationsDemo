using System;
using System.Linq;
using Demo2.Entities;
using Demo2.Infrastructure;

namespace Demo2.Orders.Query
{
    public class OrderTypesQueryContext : IOrderTypesQueryContext
    {
        private readonly RemontOnlineDbContext _remontOnlineDbContext;

        public OrderTypesQueryContext(RemontOnlineDbContext remontOnlineDbContext)
        {
          if (remontOnlineDbContext == null)
                throw new ArgumentNullException(nameof(remontOnlineDbContext));

            _remontOnlineDbContext = remontOnlineDbContext;
        }

        public IQueryable<OrderType> OrderTypes => _remontOnlineDbContext.OrderTypes;
    }
}