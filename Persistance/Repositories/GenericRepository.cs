using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;
using Persistance.Repositories.Contracts;

namespace Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataDbContext _dbContext;

        public GenericRepository(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _dbContext.Set<T>().ToListAsync();

        public async Task<T> GetAsync(int id) => 
            await _dbContext.Set<T>().FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public void UpdateAsync(T entity) =>
            _dbContext.Entry(entity).State = EntityState.Modified;

        public void DeleteAsync(T entity) =>
            _dbContext.Set<T>().Remove(entity);
    }
}
