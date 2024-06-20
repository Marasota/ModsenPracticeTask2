using OnlineStore.DAL.Entities;

namespace OnlineStore.DAL.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
    }
}