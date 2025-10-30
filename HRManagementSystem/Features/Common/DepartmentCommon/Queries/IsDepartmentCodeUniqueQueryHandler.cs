using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.Common.DepartmentCommon.Queries
{
    public sealed class IsDepartmentCodeUniqueQueryHandler : RequestHandlerBase<IsDepartmentCodeUniqueQuery, RequestResult<bool>, Department, int>
    {
        public IsDepartmentCodeUniqueQueryHandler(RequestHandlerBaseParameters<Department, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(IsDepartmentCodeUniqueQuery request, CancellationToken ct)
        {
            //   وجود قسم بنفس الكود تحت نفس الفرع
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
