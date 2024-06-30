using FluentValidation;
using OnlineStore.BLL.DTOs;
using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.BLL.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .Length(1, 50).WithMessage("Username must be between 1 and 50 characters.")
                .MustAsync(async (username, cancellation) => {
                    var existingUser = await _userRepository.GetUserByUserNameAsync(username);
                    return existingUser == null;
                }).WithMessage("Username already exists.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
