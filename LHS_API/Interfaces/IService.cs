namespace LHS_API.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> CallService_GetAll();
        Task CallService_Create(T obj);
        Task CallService_Update(string _id, T obj);
        Task CallService_Delete(string _id);
        Task<T> CallService_GetOneRow(string _id);
    }
}
