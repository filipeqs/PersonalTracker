using Application.Dtos.Exercise;
using Application.Dtos.Exercise.Validators;
using AutoMapper;
using Domain;
using MediatR;
using Persistance.Data;

namespace Application.Commands.Exercises.CreateExercise
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, Unit>
    {
        private readonly DataDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateExerciseCommandHandler(DataDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateExerciseDtoValidator();
            var validationResult = validator.Validate(request.CreateExerciseDto);

            if (validationResult.IsValid == false)
            {
                request.Success = false;
                request.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return Unit.Value;
            }

            var exercise = _mapper.Map<Exercise>(request.CreateExerciseDto);

            _dbContext.Add(exercise);
            await _dbContext.SaveChangesAsync();

            request.Exercise = _mapper.Map<ExerciseDetailsDto>(exercise);

            return Unit.Value;
        }
    }
}
