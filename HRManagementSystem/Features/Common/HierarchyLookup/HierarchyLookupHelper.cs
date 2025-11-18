using HRManagementSystem.Data.Contexts.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.Common.HierarchyLookup;

public sealed class HierarchyLookupHelper : IHierarchyLookupHelper
{
    private readonly ApplicationDbContext _context;

    public HierarchyLookupHelper(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RequestResult<List<HierarchyLookupItem<TKey>>>> GetHierarchyAsync<TParent, TChild, TKey>(
        TKey? parentId,
        CancellationToken ct)
        where TParent : BaseModel<TKey>
        where TChild : BaseModel<TKey>
        where TKey : struct
    {
        var query = _context.Set<TChild>()
                            .AsNoTracking()
                            .Where(entity => !entity.IsDeleted);

        if (parentId is not null)
        {
            var parentProperty = $"{typeof(TParent).Name}Id";

            if (typeof(TChild).GetProperty(parentProperty) is null)
            {
                return RequestResult<List<HierarchyLookupItem<TKey>>>.Failure(
                    $"{typeof(TChild).Name} does not contain property '{parentProperty}'.",
                    ErrorCode.BadRequest);
            }

            query = query.Where(entity =>
                EF.Property<TKey>(entity, parentProperty)!.Equals(parentId.Value));
        }

        if (typeof(TChild).GetProperty("Name") is null)
        {
            return RequestResult<List<HierarchyLookupItem<TKey>>>.Failure(
                $"{typeof(TChild).Name} does not contain property 'Name'.",
                ErrorCode.BadRequest);
        }

        var lookups = await query
            .OrderBy(entity => EF.Property<string>(entity, "Name"))
            .Select(entity => new HierarchyLookupItem<TKey>(
                entity.Id,
                EF.Property<string>(entity, "Name") ?? string.Empty))
            .ToListAsync(ct);

        return RequestResult<List<HierarchyLookupItem<TKey>>>.Success(lookups);
    }
}

