using System.Linq.Expressions;

namespace Movie_API.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T,bool>>?filter = null);
        Task CreateAsync(T entity);
        Task SaveAsync();
    }
}
