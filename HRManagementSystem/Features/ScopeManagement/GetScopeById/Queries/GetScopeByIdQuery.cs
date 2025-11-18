using HRManagementSystem.Data.Models.Scopes;

namespace HRManagementSystem.Features.ScopeManagement.GetScopeById.Queries
{
    public sealed record GetScopeByIdQuery(Guid Id) : IRequest<RequestResult<ViewScopeByIdDto>>;

    public sealed class GetScopeByIdQueryHandler
        : RequestHandlerBase<GetScopeByIdQuery, RequestResult<ViewScopeByIdDto>, Scope, Guid>
    {
        public GetScopeByIdQueryHandler(RequestHandlerBaseParameters<Scope, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<ViewScopeByIdDto>> Handle(GetScopeByIdQuery request, CancellationToken ct)
        {
            var scope = await _generalRepo.GetByIdAsync(request.Id);

            if (scope == null || scope.IsDeleted)
            {
                return RequestResult<ViewScopeByIdDto>.Failure("Scope not found.", ErrorCode.NotFound);
            }

            var mapped = _mapper.Map<ViewScopeByIdDto>(scope);
            return RequestResult<ViewScopeByIdDto>.Success(mapped);
        }
    }
}

