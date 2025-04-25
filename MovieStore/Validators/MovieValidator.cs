using FluentValidation;
using MovieStore.Domain;

namespace MovieStore.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Year).InclusiveBetween(1900, DateTime.Now.Year);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.DirectorId).GreaterThan(0);
            RuleFor(x => x.GenreId).GreaterThan(0);
        }
    }
}
