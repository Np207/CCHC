

using LHS_API.Interfaces;

namespace LHS_API.Services
{
    public class BaseService<TModel, TRepo> : IService<TModel> 
    where TModel : class
    where TRepo : IRepository<TModel>
    {
        protected readonly TModel _service;
        protected readonly TRepo _thisRepo;

        public BaseService(TRepo thisRepo)
        {
            _thisRepo = thisRepo;
        }

        public Task CallService_Create(TModel obj)
        {
            return _thisRepo.GetAllAsync();
        }

        public Task CallService_Delete(string _id)
        {
            return _thisRepo.DeleteAsync(_id);
        }

        public Task CallService_Update(string _id, TModel obj)
        {
            return _thisRepo.UpdateAsync(_id, obj);
        }

        public Task<IEnumerable<TModel>> CallService_GetAll()
        {
            return _thisRepo.GetAllAsync();
        }

        public Task<TModel> CallService_GetOneRow(string _id)
        {
            return _thisRepo.GetOneAsync(_id);
        }
    }
}
