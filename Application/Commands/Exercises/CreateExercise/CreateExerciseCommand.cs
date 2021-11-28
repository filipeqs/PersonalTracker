using Application.Dtos.Exercise;
using MediatR;

namespace Application.Commands.Exercises.CreateExercise
{
    public class CreateExerciseCommand : IRequest<CreateExerciseDto>
    {
        public CreateExerciseCommand(CreateExerciseDto createExerciseDto)
        {
            CreateExerciseDto = createExerciseDto;
        }

        public CreateExerciseDto CreateExerciseDto { get; }
    }
}
