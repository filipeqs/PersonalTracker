using Application.Dtos.Exercise;
using MediatR;

namespace Application.Queries.Exercises.GetExerciseList
{
    public class GetExerciseListQuery : IRequest<IEnumerable<ExerciseListDto>>
    {
    }
}
