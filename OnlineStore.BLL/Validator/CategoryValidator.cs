using FluentValidation;
using OnlineStore.BLL.DTOs;

namespace OnlineStore.BLL.Validator
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Category name is required.")
                                .MaximumLength(100).WithMessage("Category name must be less than 100 characters.");
        }
    }


}
