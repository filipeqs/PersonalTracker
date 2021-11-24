using Domain;
using Persistance.Data;
using Persistance.Repositories.Contracts;

namespace Persistance.Repositories
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(DataDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
