using HRManagementSystem.Common.Views;
using HRManagementSystem.Data.Models.Scopes;

namespace HRManagementSystem.Features.ScopeManagement.GetAllScopes.Queries
{
    public sealed record GetAllScopesQuery(int PageNumber, int PageSize)
        : IRequest<RequestResult<PagedList<ViewScopeDto>>>;

    public sealed class GetAllScopesQueryHandler
        : RequestHandlerBase<GetAllScopesQuery, RequestResult<PagedList<ViewScopeDto>>, Scope, Guid>
    {
        public GetAllScopesQueryHandler(RequestHandlerBaseParameters<Scope, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<PagedList<ViewScopeDto>>> Handle(GetAllScopesQuery request, CancellationToken ct)
        {
            var queryable = _generalRepo.Get(x => !x.IsDeleted, ct);

            var pagedList = await PagedList<ViewScopeDto>.CreateAsync(
                queryable,
                request.PageNumber,
                request.PageSize,
                _mapper,
                ct);

            return RequestResult<PagedList<ViewScopeDto>>.Success(pagedList);
        }
    }
}

