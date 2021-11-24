using Persistance.Data;
using Persistance.Repositories.Contracts;

namespace Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataDbContext _dbContext;
        private IExerciseRepository _exerciseRepository { get; set; }

        public UnitOfWork(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IExerciseRepository ExerciseRepository { get => _exerciseRepository ??= new ExerciseRepository(_dbContext); }
        public async Task SaveAsync() =>
            await _dbContext.SaveChangesAsync();

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
