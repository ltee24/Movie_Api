using Microsoft.EntityFrameworkCore;
using Movie_API.Data;
using Movie_API.Repository.IRepository;
using System.Linq.Expressions;

namespace Movie_API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MovieDbContext _db;
        internal DbSet<T> _dbset;

        public Repository(MovieDbContext db)
        {
            _db = db;
            this._dbset= _db.Set<T>();
            
        }
        public async Task CreateAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbset;
            if(filter != null)
            {
                query = query.Where(filter);
               
            }
            return await query.FirstOrDefaultAsync();

        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
