<<<<<<< HEAD
﻿using OnlineStore.BLL.DTOs;
using OnlineStore.DAL.Entities;
using System;
=======
﻿using System;
>>>>>>> origin/anna_m
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Services.Interfaces
{
<<<<<<< HEAD
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(int id);
    }

=======
    internal class IUserService
    {
    }
>>>>>>> origin/anna_m
}
