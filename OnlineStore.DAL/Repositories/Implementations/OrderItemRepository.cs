using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.DAL.Repositories.Implementations
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}