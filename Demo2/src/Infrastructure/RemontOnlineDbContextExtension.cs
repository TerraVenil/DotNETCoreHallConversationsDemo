using System;
using System.Linq;
using Demo2.Entities;

namespace Demo2.Infrastructure
{
    public static class RemontOnlineDbContextExtension
    {
        public static void EnsureSeedData(this RemontOnlineDbContext context)
        {
            if (context.AllMigrationsApplied())
            {
                if (!context.Orders.Any())
                {
                    var orderType1 = context.OrderTypes.Add(new OrderType { Name = "Paid" }).Entity;
                    var orderType2 = context.OrderTypes.Add(new OrderType { Name = "Under Guarantee" }).Entity;

                    context.SaveChanges();

                    var orderStatus1 = context.OrderStatuses.Add(new OrderStatus { Name = "New" }).Entity;
                    var orderStatus2 = context.OrderStatuses.Add(new OrderStatus { Name = "In Progress" }).Entity;

                    context.SaveChanges();

                    context.Orders.AddRange(
                        new Order { OrderNumber = "AA5caae877-1d66-448a-973f-c2cb79ccd42a", Price = 12.95M, OrderStatus = orderStatus1, OrderType = orderType1, Comment = "Biggest tech company in the world", DeadlineTime = DateTime.Now.AddDays(24), CallMasterTime = DateTime.Now.AddDays(4), IsUrgently = true },
                        new Order { OrderNumber = "AAa93977fc-8a92-40a8-9a67-20c0bb04969c", Price = 49.95M, OrderStatus = orderStatus2, OrderType = orderType1, Comment = "Looks fine", DeadlineTime = DateTime.Now.AddDays(35), CallMasterTime = DateTime.Now.AddDays(7), IsUrgently = true },
                        new Order { OrderNumber = "AAff2ea3bb-43bd-4324-86b7-2dcf0f7b4f17", Price = 123.95M, OrderStatus = orderStatus1, OrderType = orderType2, Comment = "Need more assistance", DeadlineTime = DateTime.Now.AddDays(89), CallMasterTime = DateTime.Now.AddDays(2), IsUrgently = false });

                    context.SaveChanges();
                }
            }
        }
    }
}