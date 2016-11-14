using Demo2.Orders.Models;

namespace Demo2.Orders.Extension
{
    public static class OrderModelExtension
    {
        public static OrderModel WithStatusId(this OrderModel model, int statusId)
        {
            model.StatusId = statusId;
            return model;
        }
    }
}