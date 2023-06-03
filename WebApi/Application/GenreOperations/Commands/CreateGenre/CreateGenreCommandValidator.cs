using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator :AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(commands=> commands.Model.Name).NotEmpty().MinimumLength(2);
            
        }

    }
}