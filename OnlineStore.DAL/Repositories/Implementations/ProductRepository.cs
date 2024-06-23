using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await GetByConditionAsync(p => p.CategoryId == categoryId);
        }
        /*public class OrderRepository : Repository<Order>, IOrderRepository
        {
            public OrderRepository(ApplicationDbContext context) : base(context) { }

            public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
            {
                return await GetByConditionAsync(order => order.UserId == userId);
            }
        }*/
    }
}
