using FluentValidation;
using FluentValidation.Results;

namespace CepediFullStack.Application.Validators
{
    public static class Validator
    {
        public static ValidationResult Validate<T>(IValidator<T> validator, T model) 
            => validator.Validate(model);
    }
}