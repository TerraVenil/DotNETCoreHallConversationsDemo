using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Demo2.Orders.Mappers;
using Demo2.Orders.Query;

namespace Demo2.Orders.Controllers
{
    [Route(OrdersRouteConstants.OrderTypesControllerRoutePrefix)]
    public class OrderTypesQueryController : Controller
    {
        private readonly IOrderTypesQueryContext _orderTypesQueryContext;

        public OrderTypesQueryController(IOrderTypesQueryContext orderTypesQueryContext)
        {
            if (orderTypesQueryContext == null)
                throw new ArgumentNullException(nameof(orderTypesQueryContext));

            _orderTypesQueryContext = orderTypesQueryContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderTypes()
        {
            var orderTypesModels = await _orderTypesQueryContext
                .OrderTypes.Select(x => x.ToOrderTypeModel())
                .ToListAsync();

            return new OkObjectResult(orderTypesModels);
        }
    }
}