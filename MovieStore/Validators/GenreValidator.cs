using FluentValidation;
using MovieStore.Domain;

namespace MovieStore.Validators
{
    public class GenreValidator : AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
