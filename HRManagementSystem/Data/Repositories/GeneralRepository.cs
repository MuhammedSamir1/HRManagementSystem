using HRManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;

namespace HRManagementSystem.Data.Repositories
{
    public class GeneralRepository<TEntity, TKey> : IGeneralRepository<TEntity, TKey> where TEntity : BaseModel<TKey>
    {
        protected readonly ApplicationDbContext.ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GeneralRepository(ApplicationDbContext.ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<bool> ExistsByNameAsync<T>(string name, bool IsDeleted = false, CancellationToken ct = default) where T : class
        {
            return await _context.Set<T>().AnyAsync(e =>
                    EF.Property<string>(e, "Name").ToUpper().Trim() == name.ToUpper().Trim() && !IsDeleted, ct);
        }
        public IQueryable<TEntity> GetAll()
        {
            var res = _dbSet.Where(x => !x.IsDeleted);
            return res;
        }
        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            var res = await _dbSet.Where(x => x.Id!.Equals(id) && !x.IsDeleted).FirstOrDefaultAsync();
            return res;
        }
        public async Task<TEntity> GetByIdWithTracking(TKey id)
        {
            var res = await _dbSet.AsTracking().Where(x => x.Id!.Equals(id) && !x.IsDeleted).FirstOrDefaultAsync();
            return res;
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, CancellationToken ct)
        {
            var res = GetAll().Where(expression);
            return res;
        }
        public async Task<bool> IsExistAsync(TKey id, CancellationToken ct)
        {
            return await _dbSet
                .AsNoTracking()
                .AnyAsync(e => EF.Property<TKey>(e, "Id")!.Equals(id) &&
                !EF.Property<bool>(e, "IsDeleted"),
                ct);
        }
        public async Task<bool> AddAsync(TEntity entity, CancellationToken ct)
        {
            if (entity is null)
                return false;
            await _dbSet.AddAsync(entity, ct);

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateIncludeAsync(TEntity entity, CancellationToken ct, params string[] modifiedProps)
        {
            //if (modifiedProps is null || modifiedProps.Length == 0)
            //    return false;

            var isExist = await _dbSet.AsNoTracking()
                .AnyAsync(x => x.Id!.Equals(entity.Id) && !x.IsDeleted);
            if (!isExist) return false;


            var localEntity = _dbSet.Local.FirstOrDefault(e => e.Id!.Equals(entity.Id));
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
        public async Task<bool> UpdateAsync(TEntity entity, CancellationToken ct)
        {
            //if (entity is null)
            //    return false;

            //var exists = await _dbSet.AsNoTracking()
            //                         .AnyAsync(x => x.Id!.Equals(entity.Id) && !x.IsDeleted);
            //if (!exists) return false;

            var tracked = _context.ChangeTracker.Entries<TEntity>()
                                  .FirstOrDefault(e => e.Entity.Id!.Equals(entity.Id));

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
        public async Task<bool> SoftDeleteAsync(TKey id, CancellationToken cancellationToken)
        {
            var affected = await _dbSet
                  .AsNoTracking()
                  .Where(x => EF.Property<TKey>(x, "Id")!.Equals(id) && !x.IsDeleted)
                  .ExecuteUpdateAsync(s => s
                      .SetProperty(p => p.IsDeleted, true)
                      .SetProperty(p => p.IsActive, false)
                      .SetProperty(p => p.UpdatedAt, DateTime.UtcNow),
                      cancellationToken
                  );
            await _context.SaveChangesAsync();
            return affected > 0;
        }


        //Update Without update FKs
        public async Task<bool> UpdatePartialAsync(TEntity entity, IEnumerable<string>? propsToUpdate = null,
            CancellationToken ct = default)
        {
            // لو فيه نسخة متتبَّعة في نفس السياق
            var tracked = _context.ChangeTracker.Entries<TEntity>()
                                  .FirstOrDefault(e => e.Entity.Id!.Equals(entity.Id));

            if (tracked is not null)
            {
                var source = _context.Entry(entity);
                var fkNames = GetForeignKeyNames(tracked);

                if (propsToUpdate is not null)
                {
                    foreach (var name in propsToUpdate.Distinct(StringComparer.OrdinalIgnoreCase))
                    {
                        if (!PropertyExists(tracked, name)) continue;
                        if (IsSystemField(name) || fkNames.Contains(name)) continue;

                        tracked.Property(name).CurrentValue = source.Property(name).CurrentValue;
                        tracked.Property(name).IsModified = true;
                    }
                }
                else
                {
                    foreach (var p in tracked.Properties)
                    {
                        var name = p.Metadata.Name;
                        if (p.Metadata.IsPrimaryKey()) continue;
                        if (IsSystemField(name) || fkNames.Contains(name)) continue;

                        var srcProp = source.Property(name);
                        if (IsProvided(srcProp))
                        {
                            p.CurrentValue = srcProp.CurrentValue;
                            p.IsModified = true;
                        }
                    }
                }

                // امنع تعديل FKs والسيستمية احتياطيًا
                PreventSystemAndFkModification(tracked, fkNames);
            }
            else
            {
                // Detached: Attach ثم علّم اللي مطلوب فقط
                _dbSet.Attach(entity);
                var entry = _context.Entry(entity);
                entry.State = EntityState.Unchanged;

                var fkNames = GetForeignKeyNames(entry);

                if (propsToUpdate is not null)
                {
                    foreach (var name in propsToUpdate.Distinct(StringComparer.OrdinalIgnoreCase))
                    {
                        if (!PropertyExists(entry, name)) continue;
                        if (IsSystemField(name) || fkNames.Contains(name)) continue;

                        entry.Property(name).IsModified = true;
                    }
                }
                else
                {
                    foreach (var p in entry.Properties)
                    {
                        var name = p.Metadata.Name;
                        if (p.Metadata.IsPrimaryKey()) continue;
                        if (IsSystemField(name) || fkNames.Contains(name)) continue;

                        if (IsProvided(p))
                            p.IsModified = true;
                    }
                }

                PreventSystemAndFkModification(entry, fkNames);
            }

            return await _context.SaveChangesAsync(ct) > 0;
        }
        /* ========== Helpers ========== */
        private static HashSet<string> GetForeignKeyNames(EntityEntry entry)
            => entry.Metadata.GetForeignKeys()
                 .SelectMany(fk => fk.Properties)
                 .Select(p => p.Name)
                 .ToHashSet(StringComparer.OrdinalIgnoreCase);
        private static void PreventSystemAndFkModification(EntityEntry entry, HashSet<string> fkNames)
        {
            // PK
            foreach (var pk in entry.Metadata.FindPrimaryKey()?.Properties ?? Array.Empty<IProperty>())
                entry.Property(pk.Name).IsModified = false;

            // System fields
            TryUnmod(entry, "IsDeleted");
            TryUnmod(entry, "CreatedAt");
            TryUnmod(entry, "CreatedBy");

            // كل الـFKs
            foreach (var n in fkNames)
                TryUnmod(entry, n);
        }
        private static void TryUnmod(EntityEntry entry, string name)
        {
            if (entry.Metadata.FindProperty(name) is not null)
                entry.Property(name).IsModified = false;
        }
        private static bool PropertyExists(EntityEntry entry, string name)
            => entry.Metadata.FindProperty(name) is not null;
        private static bool IsSystemField(string name)
            => name.Equals("Id", StringComparison.OrdinalIgnoreCase)
            || name.Equals("IsDeleted", StringComparison.OrdinalIgnoreCase)
            || name.Equals("CreatedAt", StringComparison.OrdinalIgnoreCase)
            || name.Equals("CreatedBy", StringComparison.OrdinalIgnoreCase);
        /// نعتبر الخاصية "مرسَلة" لو:
        /// - string: ليست null
        /// - Nullable<T>: ليست null
        /// - ValueType: ليست default(T)
        private static bool IsProvided(PropertyEntry prop)
        {
            var t = prop.Metadata.ClrType;
            var v = prop.CurrentValue;

            if (t == typeof(string)) return v is string s && s != null;

            if (Nullable.GetUnderlyingType(t) is not null) return v is not null;

            if (t.IsValueType)
            {
                var def = Activator.CreateInstance(t);
                return !Equals(v, def);
            }
            return false;
        }

    }
}
