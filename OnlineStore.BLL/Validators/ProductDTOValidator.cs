using FluentValidation;
using OnlineStore.BLL.DTOs;

namespace OnlineStore.BLL.Validators
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Product description is required.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than 0.");

            //RuleFor(p => p.CategoryId)
            //    .GreaterThan(0).WithMessage("Product category is required.");
        }
    }
}
