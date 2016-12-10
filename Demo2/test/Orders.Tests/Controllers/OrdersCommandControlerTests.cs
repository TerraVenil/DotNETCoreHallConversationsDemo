using Demo2.Orders.Command;
using Demo2.Orders.Controllers;
using Demo2.Orders.Query;
using NSubstitute;
using Xunit;

namespace Demo2.Orders.Tests.Controllers
{
    public class OrdersCommandControllerTests
    {
        [Fact]
        public void OrdersCommandControllerInitializedTest()
        {
            // Arrange
            var queryContext = Substitute.For<IOrderStatusesQueryContext>();
            var commandContext = Substitute.For<IOrdersCommandContext>();
            var controller = new OrdersCommandController(queryContext, commandContext);

            // Assert
            Assert.True(controller != null);
        }
    }
}