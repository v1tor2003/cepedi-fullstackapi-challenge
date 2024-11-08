using FluentValidation;

namespace CepediFullStack.Application.Dtos.Product
{
    public sealed class ProductValidator : AbstractValidator<ProductRequest>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product.Name is required.")
                .MaximumLength(50).WithMessage("Product.Name must be 50 characters or fewer.");

            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("Product.Type is required.")
                .MaximumLength(50).WithMessage("Product.Type must be 50 characters or fewer.");

            RuleFor(p => p.Price)
                .NotNull().WithMessage("Product.Price must be specified.");
        }
    }
}