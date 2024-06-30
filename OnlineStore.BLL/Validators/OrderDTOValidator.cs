using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OnlineStore.BLL.DTOs;


namespace OnlineStore.BLL.Validators
{
    public class OrderDTOValidator : AbstractValidator<OrderDTO>
    {
        public OrderDTOValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
            RuleFor(x => x.OrderDate).NotEmpty().WithMessage("Order date is required.");
            RuleForEach(x => x.OrderItems).SetValidator(new OrderItemDTOValidator());
        }
    }

}
