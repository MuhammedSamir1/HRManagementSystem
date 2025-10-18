using HRManagementSystem.Data.Models;
using System.Linq.Expressions;

namespace HRManagementSystem.Data.Repositories
{
    public interface IGeneralRepository<TEntity, TKey> where TEntity : BaseModel<TKey>
    {
        public IQueryable<TEntity> GetAll();
        public Task<TEntity> GetByIdAsync(TKey id);
        public Task<TEntity> GetByIdWithTracking(TKey id);
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        public Task<bool> IsExistAsync(TKey id, CancellationToken ct);
        public Task<bool> AddAsync(TEntity entity, CancellationToken ct);
        public Task<bool> UpdateIncludeAsync(TEntity entity, params string[] modifiedProps);
        public Task<bool> UpdateAsync(TEntity entity, CancellationToken ct);
        public Task<bool> SoftDeleteAsync(int id);
    }
}
