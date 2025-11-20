namespace LHS_API.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T obj);
        Task UpdateAsync(string _id, T obj);
        Task DeleteAsync(string _id);
        Task<T> GetOneAsync(string _id);
    }
}
