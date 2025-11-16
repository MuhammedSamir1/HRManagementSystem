namespace HRManagementSystem.Features.Common.CompanyCommon.IsCompanyExist.Queries
{
    public sealed record IsCompanyExistQuery(Guid companyId) : IRequest<RequestResult<bool>>;

    public sealed class IsCompanyExistQueryHandler : RequestHandlerBase<IsCompanyExistQuery,
        RequestResult<bool>, Company, Guid>
    {
        public IsCompanyExistQueryHandler(RequestHandlerBaseParameters<Company, Guid> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(IsCompanyExistQuery request, CancellationToken ct)
        {
            var isExist = await _generalRepo.IsExistAsync(request.companyId, ct);
            if (!isExist) return RequestResult<bool>.Failure(ErrorCode.OrganizationNotFound);
            return RequestResult<bool>.Success(true);
        }
    }
}

