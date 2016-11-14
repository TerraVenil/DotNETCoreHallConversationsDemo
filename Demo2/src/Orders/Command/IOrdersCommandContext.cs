using System.Threading.Tasks;
using Demo2.Entities;

namespace Demo2.Orders.Command
{
    public interface IOrdersCommandContext
    {
        Task CreateOrder(Order order);
    }
}