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
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryDto сategoryDto);
        Task UpdateCategoryAsync(CategoryDto сategoryDto);
        Task DeleteCategoryAsync(int id);
    }

=======
    internal class ICategoryService
    {
    }
>>>>>>> origin/anna_m
}
