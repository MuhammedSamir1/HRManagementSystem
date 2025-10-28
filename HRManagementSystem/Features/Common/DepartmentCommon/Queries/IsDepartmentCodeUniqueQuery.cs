using HRManagementSystem.Common.Views.Response;
using MediatR;

namespace HRManagementSystem.Features.Common.DepartmentCommon.Queries
{
    public sealed record IsDepartmentCodeUniqueQuery(int BranchId, string Code) : IRequest<RequestResult<bool>>;
}
