using FluentValidation;
using OnlineStore.BLL.DTOs;
using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.BLL.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(c => c.Name).NotEmpty().WithMessage("Category name is required.")
                                .MaximumLength(100).WithMessage("Category name must be less than 100 characters.");

            RuleFor(c => c).MustAsync(async (categoryDto, cancellation) =>
            {
                var existingCategory = await _categoryRepository.GetCategoryByNameAsync(categoryDto.Name);
                return existingCategory == null;
            }).WithMessage("Category with the same name already exists.");
        }
    }
}
