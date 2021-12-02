using FluentValidation;

namespace Application.Dtos.Exercise.Validators
{
    public class CreateExerciseDtoValidator : AbstractValidator<CreateExerciseDto>
    {
        public CreateExerciseDtoValidator()
        {
            RuleFor(x => x.Id).Empty().WithMessage("Can't have an {PropertyName}");
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} must be present.");
            RuleFor(x => x.Description).NotNull().WithMessage("{PropertyName} must be present.");
        }
    }
}
