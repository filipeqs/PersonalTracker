using Application.Dtos.Exercise;
using MediatR;

namespace Application.Commands.Exercises.UpdateExercise
{
    public class UpdateExerciseCommand : IRequest<Unit>
    {
        public UpdateExerciseCommand(UpdateExerciseDto updateExerciseDto)
        {
            UpdateExerciseDto = updateExerciseDto;
        }

        public UpdateExerciseDto UpdateExerciseDto { get; }
        public bool Success { get; set; } = true;
        public List<string> Errors { get; set; }
        public ExerciseDetailsDto Exercise { get; set; }
    }
}
