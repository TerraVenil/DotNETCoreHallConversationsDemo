using Demo2.Entities;
using Demo2.Orders.Models;

namespace Demo2.Orders.Mappers
{
    public static class OrderTypeMapper
    {
        public static OrderTypeModel ToOrderTypeModel(this OrderType entity)
        {
            var order = new OrderTypeModel
                        {
                            Id = entity.Id,
                            Name = entity.Name
                        };

            return order;
        }
    }
}