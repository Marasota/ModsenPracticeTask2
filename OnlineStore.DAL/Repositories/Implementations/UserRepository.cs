using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.DAL.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
