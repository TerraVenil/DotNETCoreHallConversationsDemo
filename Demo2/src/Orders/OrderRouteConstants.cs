namespace Demo2.Orders
{
    public static class OrdersRouteConstants
    {
        public const string RootApiRoutePrefix = "api/v1"; 

        public const string ControllerRoutePrefix = RootApiRoutePrefix + "/[controller]";

        public const string OrdersControllerRoutePrefix = RootApiRoutePrefix + "/orders";

        public const string OrderTypesControllerRoutePrefix = RootApiRoutePrefix + "/order_types";
    }
}