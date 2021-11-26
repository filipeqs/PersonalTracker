using Application.Dtos.Exercise;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;

namespace Application.Queries.Exercises.GetExerciseList
{
    public class GetExerciseListQueryHandler : IRequestHandler<GetExerciseListQuery, IEnumerable<ExerciseListDto>>
    {
        private readonly DataDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetExerciseListQueryHandler(DataDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseListDto>> Handle(GetExerciseListQuery request, CancellationToken cancellationToken)
        {
            var exercises = await _dbContext.Exercises.ToListAsync();
            return _mapper.Map<IEnumerable<ExerciseListDto>>(exercises);
        }
    }
}
