using FluentValidation;
using OnlineStore.BLL.DTOs.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Validators.Register
{
    namespace OnlineStore.BLL.Validators
    {
        public class UserLoginValidator : AbstractValidator<UserLoginDto>
        {
            public UserLoginValidator()
            {
                RuleFor(user => user.UserName)
                    .NotEmpty().WithMessage("Username is required.");

                RuleFor(user => user.Password)
                    .NotEmpty().WithMessage("Password is required.");
            }
        }
    }
}
