namespace HRManagementSystem.Features.Common.HierarchyLookup;

public interface IHierarchyLookupRequest<TKey> : IRequest<RequestResult<List<HierarchyLookupItem<TKey>>>>
    where TKey : struct
{
    TKey? ParentId { get; }
}

public abstract class HierarchyLookupHandlerBase<TRequest, TParent, TChild, TKey> :
    RequestHandlerBase<TRequest, RequestResult<List<HierarchyLookupItem<TKey>>>, TChild, TKey>
    where TRequest : IHierarchyLookupRequest<TKey>
    where TChild : BaseModel<TKey>
    where TParent : BaseModel<TKey>
    where TKey : struct
{
    private readonly IHierarchyLookupHelper _lookupHelper;

    protected HierarchyLookupHandlerBase(
        RequestHandlerBaseParameters<TChild, TKey> parameters,
        IHierarchyLookupHelper lookupHelper)
        : base(parameters)
    {
        _lookupHelper = lookupHelper;
    }

    public override Task<RequestResult<List<HierarchyLookupItem<TKey>>>> Handle(
        TRequest request,
        CancellationToken ct)
        => _lookupHelper.GetHierarchyAsync<TParent, TChild, TKey>(request.ParentId, ct);
}

