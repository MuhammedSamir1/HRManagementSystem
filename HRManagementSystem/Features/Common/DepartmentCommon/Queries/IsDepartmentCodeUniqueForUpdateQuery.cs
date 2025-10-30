namespace HRManagementSystem.Features.Common.DepartmentCommon.Queries
{
    public sealed record IsDepartmentCodeUniqueForUpdateQuery(int DepartmentId, int BranchId, string Code)
        : IRequest<RequestResult<bool>>;
}
