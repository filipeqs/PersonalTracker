namespace Persistance.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        public IExerciseRepository ExerciseRepository { get; }
        Task SaveAsync();
        void Dispose();
    }
}
