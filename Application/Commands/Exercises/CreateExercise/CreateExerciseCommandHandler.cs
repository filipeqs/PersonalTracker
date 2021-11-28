using Application.Dtos.Exercise;
using Application.Dtos.Exercise.Validators;
using AutoMapper;
using Domain;
using MediatR;
using Persistance.Data;

namespace Application.Commands.Exercises.CreateExercise
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, CreateExerciseDto>
    {
        private readonly DataDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateExerciseCommandHandler(DataDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CreateExerciseDto> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateExerciseDtoValidator();
            var validationResult = validator.Validate(request.CreateExerciseDto);

            if (validationResult.IsValid == false)
            {
                return null;
            }

            var exercise = _mapper.Map<Exercise>(request.CreateExerciseDto);

            _dbContext.Add(exercise);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CreateExerciseDto>(exercise);
        }
    }
}
