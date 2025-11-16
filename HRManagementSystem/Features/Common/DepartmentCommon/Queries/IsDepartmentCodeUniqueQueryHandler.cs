using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.Common.DepartmentCommon.Queries
{
    public sealed class IsDepartmentCodeUniqueQueryHandler : RequestHandlerBase<IsDepartmentCodeUniqueQuery, RequestResult<bool>, Department, Guid>
    {
        public IsDepartmentCodeUniqueQueryHandler(RequestHandlerBaseParameters<Department, Guid> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(IsDepartmentCodeUniqueQuery request, CancellationToken ct)
        {
            //   ???? ??? ???? ????? ??? ??? ?????
            var isDuplicate = await _generalRepo
                .Get(d => d.Code == request.Code && d.BranchId == request.BranchId, ct)
                .AnyAsync(ct);

            if (isDuplicate)
            {
                return RequestResult<bool>.Failure($"Department code '{request.Code}' already exists in Branch ID {request.BranchId}.", ErrorCode.Conflict);
            }
            return RequestResult<bool>.Success(true);
        }
    }
}

