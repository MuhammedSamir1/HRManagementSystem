using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using MediatR;

namespace HRManagementSystem.Features.Common.CompanyCommon.IsCompanyExist.Queries
{
    public sealed record IsCompanyExistQuery(int companyId) : IRequest<RequestResult<bool>>;

    public sealed class IsCompanyExistQueryHandler : RequestHandlerBase<IsCompanyExistQuery,
        RequestResult<bool>, Company, int>
    {
        public IsCompanyExistQueryHandler(RequestHandlerBaseParameters<Company, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(IsCompanyExistQuery request, CancellationToken ct)
        {
            var isExist = await _generalRepo.IsExistAsync(request.companyId, ct);
            if (!isExist) return RequestResult<bool>.Failure(ErrorCode.OrganizationNotFound);
            return RequestResult<bool>.Success(true);
        }
    }
}
