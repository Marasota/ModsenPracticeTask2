using FluentValidation;
using OnlineStore.BLL.DTOs;

namespace OnlineStore.BLL.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .Length(1, 50).WithMessage("Username must be between 1 and 50 characters.");

            RuleFor(user => user.Password)
                    .NotEmpty().WithMessage("Password is required.")
                    .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
