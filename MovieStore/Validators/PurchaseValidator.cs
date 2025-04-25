using FluentValidation;
using MovieStore.Domain;

namespace MovieStore.Validators
{
    public class PurchaseValidator : AbstractValidator<Purchase>
    {
        public PurchaseValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0);
            RuleFor(x => x.MovieId).GreaterThan(0);
        }
    }
}
