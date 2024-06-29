
using OnlineStore.BLL.DTOs;

namespace OnlineStore.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryDto сategoryDto);
        Task UpdateCategoryAsync(CategoryDto сategoryDto);
        Task DeleteCategoryAsync(int id);
    }

}
