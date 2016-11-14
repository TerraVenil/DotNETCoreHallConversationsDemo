using System;

namespace Demo2.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; }

        public int OrderTypeId  { get; set; }
        
        public OrderType OrderType { get; set; }

        public int OrderStatusId { get; set; }

        public OrderStatus OrderStatus { get; set; }
        
        public string Comment { get; set; }

        public DateTime CallMasterTime { get; set; }

        public DateTime DeadlineTime { get; set; }

        public decimal Price { get; set; }

        public decimal PrepaidExpense { get; set; }

        public bool IsUrgently { get; set; }
    }
}