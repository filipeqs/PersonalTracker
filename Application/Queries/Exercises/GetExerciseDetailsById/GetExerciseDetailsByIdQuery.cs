using Application.Dtos.Exercise;
using MediatR;

namespace Application.Queries.Exercises.GetExerciseDetailsById
{
    public class GetExerciseDetailsByIdQuery : IRequest<ExerciseDetailsDto>
    {
        public GetExerciseDetailsByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
