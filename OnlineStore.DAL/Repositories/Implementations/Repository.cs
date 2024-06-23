using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace OnlineStore.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly OnlineStoreDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(OnlineStoreDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
