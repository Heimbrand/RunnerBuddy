namespace RunnerBuddy.Application.Interfaces;

public interface IGenericRepository<T> where T : class
{ 
    Task Add(T entity);
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task Update(T entity);
    Task Delete(T entity);
}