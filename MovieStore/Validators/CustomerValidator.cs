using FluentValidation;
using MovieStore.Domain;

namespace MovieStore.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).MinimumLength(5);
        }
    }
}
