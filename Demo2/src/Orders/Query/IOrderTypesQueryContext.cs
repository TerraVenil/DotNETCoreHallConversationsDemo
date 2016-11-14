using System.Linq;
using Demo2.Entities;

namespace Demo2.Orders.Query
{
    public interface IOrderTypesQueryContext
    {
        IQueryable<OrderType> OrderTypes { get; }
    }
}