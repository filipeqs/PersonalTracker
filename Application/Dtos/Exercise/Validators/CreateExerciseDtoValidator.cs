using FluentValidation;

namespace Application.Dtos.Exercise.Validators
{
    public class CreateExerciseDtoValidator : AbstractValidator<CreateExerciseDto>
    {
        public CreateExerciseDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} must be present.");
        }
    }
}
