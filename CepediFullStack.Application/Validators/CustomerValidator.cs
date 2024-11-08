using FluentValidation;
using CepediFullStack.Application.Dtos.Customer;
namespace CepediFullStack.Application.Validators
{
    public sealed class CustomerValidator : AbstractValidator<CustomerRequest>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name)
                    .NotEmpty().WithMessage("Customer.Name is required.")
                    .MaximumLength(100).WithMessage("Customer.Name must be 100 characters or fewer.");
            
            RuleFor(c => c.Email)
                    .NotEmpty().WithMessage("Customer.Email is required.")
                    .EmailAddress().WithMessage("Customer.Email has an invalid email format.");

            RuleFor(c => c.PhoneNumber)
                    .Matches(@"^\+?[1-9]\d{1,14}$")
                    .WithMessage("Customer.PhoneNumber must be in E.164 international format.")
                    .When(c => !string.IsNullOrEmpty(c.PhoneNumber));

            RuleFor(c => c.BirthDate)
                    .NotEmpty().WithMessage("Birth date is required.")
                    .Must(BeAtLeast18).WithMessage("Customer must be at least 18 years old.");
        }

        private bool BeAtLeast18(DateOnly birthDate)
        {
            return DateOnly.FromDateTime(DateTime.Now).Year - birthDate.Year >= 18;
        }
    }
}
