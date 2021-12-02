using Application.Dtos.Exercise;
using MediatR;

namespace Application.Commands.Exercises.CreateExercise
{
    public class CreateExerciseCommand : IRequest<Unit>
    {
        public CreateExerciseCommand(CreateExerciseDto createExerciseDto)
        {
            CreateExerciseDto = createExerciseDto;
        }

        public CreateExerciseDto CreateExerciseDto { get; }
        public bool Success { get; set; } = true;
        public List<string> Errors { get; set; }
        public CreateExerciseDto Exercise { get; set; }
    }
}
