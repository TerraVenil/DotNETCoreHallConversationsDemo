using System;
using System.Threading.Tasks;
using Demo2.Orders.Command;
using Demo2.Orders.Extension;
using Demo2.Orders.Mappers;
using Demo2.Orders.Models;
using Demo2.Orders.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo2.Orders.Controllers
{
    [Route(OrdersRouteConstants.OrdersControllerRoutePrefix)]
    public class OrdersCommandController : Controller
    {
        private readonly IOrderStatusesQueryContext _orderStatusesQueryContext;
        private readonly IOrdersCommandContext _ordersCommandContext;

        public OrdersCommandController(IOrderStatusesQueryContext orderStatusesQueryContext, IOrdersCommandContext ordersCommandContext)
        {
            if (orderStatusesQueryContext == null)
                throw new ArgumentNullException(nameof(orderStatusesQueryContext));

            if (ordersCommandContext == null)
                throw new ArgumentNullException(nameof(ordersCommandContext));

            _orderStatusesQueryContext = orderStatusesQueryContext;
            _ordersCommandContext = ordersCommandContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderStatus = await _orderStatusesQueryContext.OrderStatuses.SingleAsync(x => x.Name == "New");

            var order = model.WithStatusId(orderStatus.Id).ToOrder();
            
            await _ordersCommandContext.CreateOrder(order);

            CreatedAtRouteResult result = CreatedAtRoute("GetOrderById", new { controller = "orders", orderId = order.Id }, order);
            return result;
        }
    }
}