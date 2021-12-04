using Application.Dtos.Exercise;
using Application.Dtos.Exercise.Validators;
using AutoMapper;
using Domain;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;

namespace Application.Commands.Exercises.UpdateExercise
{
    public class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseCommand, Unit>
    {
        private readonly DataDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateExerciseCommandHandler(DataDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            var validationResult = ValidateCommand(request.UpdateExerciseDto);

            if (validationResult.IsValid == false)
            {
                request.Success = false;
                request.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return Unit.Value;
            }
            
            var exercise = await _dbContext.Exercises.FirstOrDefaultAsync(q => q.Id == request.UpdateExerciseDto.Id);
            if (exercise == null)
            {
                request.Success = false;
                request.Errors = new List<string> { "Exercise not found!" };
                return Unit.Value;
            }

            _mapper.Map(request.UpdateExerciseDto, exercise);

            _dbContext.Entry(exercise).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            request.Exercise = _mapper.Map<ExerciseDetailsDto>(exercise);

            return Unit.Value;
        }

        private ValidationResult ValidateCommand(UpdateExerciseDto updateExerciseDto)
        {
            var validator = new UpdateExerciseDtoValidator();
            return validator.Validate(updateExerciseDto);
        }
    }
}
