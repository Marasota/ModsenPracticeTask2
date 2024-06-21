using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.DAL.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
