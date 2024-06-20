using OnlineStore.DAL.Entities;

namespace OnlineStore.DAL.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    }
}
