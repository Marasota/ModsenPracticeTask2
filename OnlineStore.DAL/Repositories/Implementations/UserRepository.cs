﻿using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.DAL.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly OnlineStoreDbContext _context;

        public UserRepository(OnlineStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
