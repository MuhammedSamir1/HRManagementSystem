using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;

namespace HRManagementSystem.Features.Common.BranchCommon.Queries
{
    public sealed class IsBranchValidQueryHandler : RequestHandlerBase<IsBranchValidQuery, RequestResult<bool>, Branch, int>
    {
        public IsBranchValidQueryHandler(RequestHandlerBaseParameters<Branch, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(IsBranchValidQuery request, CancellationToken ct)
        {
            
            var isExist = await _generalRepo.IsExistAsync(request.BranchId, ct);

            if (!isExist)
            {
                return RequestResult<bool>.Failure("Parent Branch not found or is inactive.", ErrorCode.NotFound);
            }
            return RequestResult<bool>.Success(true);
        }
    }
}
