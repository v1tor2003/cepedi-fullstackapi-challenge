using CepediFullStack.Application.Dtos.Order;
using FluentValidation;

namespace CepediFullStack.Application.Validators
{
    public class OrderValidator : AbstractValidator<OrderRequest>
    {
        public OrderValidator()
        {
            RuleFor(o => o.OrderDate)
                .NotEmpty().WithMessage("Order.OrderDate is required.");

            RuleFor(o => o.CustomerId)
                .NotNull().WithMessage("Order.CustomerId must be specified.");

            RuleFor(o => o.StatusId)
                .NotNull().WithMessage("Order.StatusName must be specified.");
        }
    }
}