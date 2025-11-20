using LHS_API.Data;
using LHS_API.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace LHS_API.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DBContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(DBContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }
 
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            var existing = await _dbSet.FindAsync(Guid.Parse(id));
            if (existing == null)
                throw new Exception("Entity not found!");

            _dbContext.Entry(existing).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var guidId = Guid.Parse(id); // If your ID is Guid stored as string
            var entity = await _dbSet.FindAsync(guidId);
            if (entity == null)
                throw new Exception("Entity not found!");

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetOneAsync(string id)
        {
            var guidId = Guid.Parse(id);

            var entity = await _dbSet.FindAsync(guidId);

            if (entity == null)
                throw new Exception("Entity not found!");

            return entity;
        }
    }
}
