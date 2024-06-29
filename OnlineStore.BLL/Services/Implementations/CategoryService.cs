
namespace OnlineStore.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidator<CategoryDto> _validator;

        public CategoryService(ICategoryRepository categoryRepository, IValidator<CategoryDto> validator)
        {
            _categoryRepository = categoryRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            });
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
        }

        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var validationResult = await _validator.ValidateAsync(categoryDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var category = new Category
            {
                Name = categoryDto.Name
            };

            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task UpdateCategoryAsync(CategoryDto categoryDto)
        {
            var validationResult = await _validator.ValidateAsync(categoryDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var category = new Category
            {
                CategoryId = categoryDto.CategoryId,
                Name = categoryDto.Name
            };

            await _categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
    {
            await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
