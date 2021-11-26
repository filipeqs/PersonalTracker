using Application.Dtos.Exercise;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;

namespace Application.Queries.Exercises.GetExerciseDetailsById
{
    public class GetExerciseDetailsByIdQueryHandler : IRequestHandler<GetExerciseDetailsByIdQuery, ExerciseDetailsDto>
    {
        private readonly DataDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetExerciseDetailsByIdQueryHandler(DataDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ExerciseDetailsDto> Handle(GetExerciseDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var exercise = await _dbContext.Exercises.FirstOrDefaultAsync(q => q.Id == request.Id);
            return _mapper.Map<ExerciseDetailsDto>(exercise);
        }
    }
}
