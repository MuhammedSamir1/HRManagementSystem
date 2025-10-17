using HRManagementSystem.Data.ApplicationDbContext;
using HRManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRManagementSystem.Data.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : BaseModel
    {
        protected readonly Context _context;
        private readonly DbSet<T> _dbSet;
        public GeneralRepository(Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> Query<T>() where T : BaseModel
        {
            return _context.Set<T>().AsNoTracking();
        }
        public IQueryable<T> QueryTracked<T>() where T : BaseModel
        {
            return _context.Set<T>();

        }
        public IQueryable<T> GetAll()
        {
            var res = _dbSet.Where(x => !x.IsDeleted);
            return res;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var res = await _dbSet.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();
            return res;
        }
        public async Task<T> GetByIdWithTracking(int id)
        {
            var res = await _dbSet.AsTracking().Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();
            return res;
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            var res = GetAll().Where(expression);
            return res;
        }
        public async Task<bool> AddAsync(T entity)
        {
            if (entity is null)
                return false;
            await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateIncludeAsync(T entity, params string[] modifiedProps)
        {
            if (modifiedProps is null || modifiedProps.Length == 0 || entity.Id <= 0)
                return false;

            var isExist = await _dbSet.AsNoTracking()
                .AnyAsync(x => x.Id == entity.Id && !x.IsDeleted);
            if (!isExist) return false;


            var localEntity = _dbSet.Local.FirstOrDefault(e => e.Id == entity.Id);
            if (localEntity is not null)
            {
                var localEntry = _context.Entry(localEntity);
                var newEntry = _context.Entry(entity);
                foreach (var prop in modifiedProps)
                {
                    var newValue = newEntry.Property(prop).CurrentValue;
                    localEntry.Property(prop).CurrentValue = newValue;
                    localEntry.Property(prop).IsModified = true;
                }
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _dbSet.Attach(entity);
                var entry = _context.Entry(entity);

                foreach (var prop in modifiedProps)
                {
                    entry.Property(prop).IsModified = true;
                }
            }
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            if (entity is null || entity.Id <= 0)
                return false;

            var exists = await _dbSet.AsNoTracking()
                                     .AnyAsync(x => x.Id == entity.Id && !x.IsDeleted);
            if (!exists) return false;

            var tracked = _context.ChangeTracker.Entries<T>()
                                  .FirstOrDefault(e => e.Entity.Id == entity.Id);

            if (tracked is not null)
            {
                tracked.CurrentValues.SetValues(entity);
            }
            else
            {
                _dbSet.Attach(entity);
                var entry = _context.Entry(entity);
                entry.State = EntityState.Modified;

                entry.Property("Id").IsModified = false;
                if (entry.Metadata.FindProperty("IsDeleted") is not null)
                    entry.Property("IsDeleted").IsModified = false;
                if (entry.Metadata.FindProperty("CreatedAt") is not null)
                    entry.Property("CreatedAt").IsModified = false;
                if (entry.Metadata.FindProperty("CreatedBy") is not null)
                    entry.Property("CreatedBy").IsModified = false;
            }

            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> SoftDeleteAsync(int id)
        {
            if (id <= 0)
                return false;

            var affected = await _dbSet
                  .Where(x => x.Id == id && !x.IsDeleted)
                  .ExecuteUpdateAsync(s => s
                      .SetProperty(p => p.IsDeleted, true)
                  );

            return affected > 0;
        }
    }
}
