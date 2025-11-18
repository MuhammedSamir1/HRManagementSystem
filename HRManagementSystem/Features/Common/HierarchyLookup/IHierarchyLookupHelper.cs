namespace HRManagementSystem.Features.Common.HierarchyLookup;

public interface IHierarchyLookupHelper
{
    Task<RequestResult<List<HierarchyLookupItem<TKey>>>> GetHierarchyAsync<TParent, TChild, TKey>(
        TKey? parentId,
        CancellationToken ct)
        where TParent : BaseModel<TKey>
        where TChild : BaseModel<TKey>
        where TKey : struct;
}

