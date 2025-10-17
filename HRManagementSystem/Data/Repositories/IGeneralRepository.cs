using HRManagementSystem.Data.Models;
using System.Linq.Expressions;

namespace HRManagementSystem.Data.Repositories
{
    public interface IGeneralRepository<T> where T : BaseModel
    {
        public IQueryable<T> Query<T>() where T : BaseModel;
        public IQueryable<T> QueryTracked<T>() where T : BaseModel;
        public IQueryable<T> GetAll();
        public Task<T> GetByIdAsync(int id);
        public Task<T> GetByIdWithTracking(int id);
        public IQueryable<T> Get(Expression<Func<T, bool>> expression);
        public Task<bool> AddAsync(T entity);
        public Task<bool> UpdateIncludeAsync(T entity, params string[] modifiedProps);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> SoftDeleteAsync(int id);
    }
}
