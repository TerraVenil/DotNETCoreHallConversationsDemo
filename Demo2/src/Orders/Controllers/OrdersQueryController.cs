using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo2.Orders.Mappers;
using Demo2.Orders.Models;
using Demo2.Orders.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo2.Orders.Controllers
{
    [Route(OrdersRouteConstants.OrdersControllerRoutePrefix)]
    public class OrdersQueryController : Controller
    {
        private readonly IOrdersQueryContext _ordersQueryContext;

        public OrdersQueryController(IOrdersQueryContext ordersQueryContext)
        {
            if (ordersQueryContext == null)
                throw new ArgumentNullException(nameof(ordersQueryContext));

            _ordersQueryContext = ordersQueryContext;
        }

        [HttpGet]
        public async Task<List<OrderModel>> GetOrders()
        {
            return await _ordersQueryContext
                .Orders
                .Include(x => x.OrderStatus)
                .Select(x => x.ToOrderModel())
                .ToListAsync();
        }

        [HttpGet("{orderId}", Name = "GetOrderById")]
        public async Task<IActionResult> GetOrderBydId(int orderId)
        {
            var order = await _ordersQueryContext.Orders
                .Include(x => x.OrderStatus)
                .FirstOrDefaultAsync(x => x.Id == orderId);

            var model = order.ToOrderModel();
            return new OkObjectResult(model);
        }
    }
}