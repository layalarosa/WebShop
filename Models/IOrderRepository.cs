using System.Threading.Tasks;

namespace WebShop.Models
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
    }
}
