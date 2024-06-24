<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Services.Interfaces
{
    internal class IProductService
    {
=======
﻿using OnlineStore.BLL.DTOs;

namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetByIdAsync(int id);
        Task AddAsync(ProductDTO productDto);
        Task UpdateAsync(ProductDTO productDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(int categoryId);
>>>>>>> origin/anna_m
    }
}
