using Demo2.Entities;
using Demo2.Orders.Models;

namespace Demo2.Orders.Mappers
{
    public static class OrderMapper
    {
        public static Order ToOrder(this OrderModel model)
        {
            var order = new Order
                        {
                            OrderTypeId = model.OrderTypeId,
                            OrderStatusId = model.StatusId,
                            DeadlineTime = model.DeadlineTime,
                            Price = model.Price,
                            Comment = model.Comment,
                            IsUrgently = model.IsUrgently
                        };

            return order;
        }

        public static OrderModel ToOrderModel(this Order entity)
        {
            return new OrderModel
                   {
                       Number = entity.OrderNumber,
                       OrderTypeId = entity.OrderTypeId,
                       Status = entity.OrderStatus.Name,
                       StatusId = entity.OrderStatusId,
                       DeadlineTime = entity.DeadlineTime,
                       Comment = entity.Comment,
                       Price = entity.Price,
                       IsUrgently = entity.IsUrgently
                   };
        }
    }
}