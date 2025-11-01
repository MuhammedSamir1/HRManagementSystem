namespace HRManagementSystem.Features.Common.IsAnyChildAssignedGeneric;

public sealed record IsAnyChildAssignedQuery<TParent, TChild, TKey>(TKey ParentId)
    : IRequest<RequestResult<bool>>;

public sealed class IsAnyChildAssignedQueryHandler<TParent, TChild, TKey>
    : RequestHandlerBase<IsAnyChildAssignedQuery<TParent, TChild, TKey>, RequestResult<bool>, TChild, TKey>
    where TChild : BaseModel<TKey>
    where TParent : BaseModel<TKey>
{
    public IsAnyChildAssignedQueryHandler(RequestHandlerBaseParameters<TChild, TKey> parameters)
        : base(parameters) { }

    public override async Task<RequestResult<bool>> Handle(
        IsAnyChildAssignedQuery<TParent, TChild, TKey> request,
        CancellationToken ct)
    {
        bool hasChild = await _generalRepo.HasAnyChildAsync<TParent>(request.ParentId, ct);
        return RequestResult<bool>.Success(hasChild);
    }
}
