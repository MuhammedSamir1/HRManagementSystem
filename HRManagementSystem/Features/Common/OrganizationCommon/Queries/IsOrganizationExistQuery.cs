namespace HRManagementSystem.Features.Common.OrganizationCommon.Queries
{
    public sealed record IsOrganizationExistQuery(int Id) : IRequest<RequestResult<bool>>;

    public sealed class IsOrganizationExistQueryHandler : RequestHandlerBase<IsOrganizationExistQuery,
        RequestResult<bool>, Organization, int>
    {
        public IsOrganizationExistQueryHandler(RequestHandlerBaseParameters<Organization, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(IsOrganizationExistQuery request, CancellationToken ct)
        {
            var isExist = await _generalRepo.IsExistAsync(request.Id, ct);
            if (!isExist) return RequestResult<bool>.Failure(ErrorCode.OrganizationNotFound);
            return RequestResult<bool>.Success(true);
        }
    }
}
