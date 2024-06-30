﻿using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace OnlineStore.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> predicate);
    }

}
