using HRManagementSystem.Data.Models;
using System.Linq.Expressions;

namespace HRManagementSystem.Data.Repositories
{
    public interface IGeneralRepository<TEntity, TKey> where TEntity : BaseModel<TKey>
    {
        public Task<bool> ExistsByNameAsync<T>(string name, bool IsDeleted = false, CancellationToken ct = default) where T : class;
        public IQueryable<TEntity> GetAll();
        public Task<TEntity> GetByIdAsync(TKey id);
        public IQueryable<TEntity> GetById(TKey id);
        public Task<TEntity> GetByIdWithTracking(TKey id);
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, CancellationToken ct);
        public Task<bool> IsExistAsync(TKey id, CancellationToken ct);
        public Task<bool> AddAsync(TEntity entity, CancellationToken ct);
        public Task<bool> UpdateIncludeAsync(TEntity entity, CancellationToken ct, params string[] modifiedProps);
        public Task<bool> UpdateAsync(TEntity entity, CancellationToken ct);
        public Task<bool> SoftDeleteAsync(TKey id, CancellationToken cancellationToken);
        public Task<bool> UpdatePartialAsync(
    TEntity entity,
    IEnumerable<string>? propsToUpdate = null,
    CancellationToken ct = default);
    }
}
