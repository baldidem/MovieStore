using FluentValidation;
using MovieStore.DTOs.Actor;

namespace MovieStore.Validators
{
    public class ActorValidator : AbstractValidator<ActorDto>
    {
        public ActorValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
