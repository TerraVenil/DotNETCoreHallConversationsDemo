using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Demo2.Orders.Mappers;
using Demo2.Orders.Models;
using Demo2.Orders.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.EntityFrameworkCore;

namespace Demo2.Orders.Controllers
{
    [Route(OrdersRouteConstants.OrdersControllerRoutePrefix)]
    public class OrdersQueryController : Controller
    {
        private readonly IOrdersQueryContext _ordersQueryContext;

        private readonly INodeServices _nodeServices;

        public OrdersQueryController(IOrdersQueryContext ordersQueryContext, INodeServices nodeServices)
        {
            _ordersQueryContext = ordersQueryContext;
            _nodeServices = nodeServices;
        }

        [HttpGet]
        public async Task<List<OrderModel>> GetOrders()
        {
            var result = await _ordersQueryContext
                .Orders
                .Include(x => x.OrderStatus)
                .Select(x => x.ToOrderModel())
                .ToListAsync();

            return result;
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

        [HttpGet]
        [Route("ExportOrdersToExcelDocument")]
        public async Task<IActionResult> ExportOrdersToExcelDocument()
        {
            var orders = await _ordersQueryContext
                .Orders
                .Include(x => x.OrderStatus)
                .ToListAsync();

            var result = await _nodeServices.InvokeAsync<Stream>("js/excelExporter.js", orders);
            return File(result, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}