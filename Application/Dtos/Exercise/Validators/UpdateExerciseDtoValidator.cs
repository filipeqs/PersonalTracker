using FluentValidation;

namespace Application.Dtos.Exercise.Validators
{
    public class UpdateExerciseDtoValidator : AbstractValidator<UpdateExerciseDto>
    {
        public UpdateExerciseDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} must be present.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} must be present.");
            RuleFor(x => x.Description).NotNull().WithMessage("{PropertyName} must be present.");
        }
    }
}
