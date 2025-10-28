using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.Common.DepartmentCommon.Queries
{
    public sealed class IsDepartmentCodeUniqueForUpdateQueryHandler : RequestHandlerBase<IsDepartmentCodeUniqueForUpdateQuery, RequestResult<bool>, Department, int>
    {
        public IsDepartmentCodeUniqueForUpdateQueryHandler(RequestHandlerBaseParameters<Department, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(IsDepartmentCodeUniqueForUpdateQuery request, CancellationToken ct)
        {
            var isDuplicate = await _generalRepo
                .Get(d => d.Code == request.Code &&
                          d.BranchId == request.BranchId &&
                          d.Id != request.DepartmentId, ct) //  
                .AnyAsync(ct);

            if (isDuplicate)
            {
                return RequestResult<bool>.Failure($"Department code '{request.Code}' already exists in Branch ID {request.BranchId}.", ErrorCode.Conflict);
            }
            return RequestResult<bool>.Success(true);
        }
    }
}
