namespace HRManagementSystem.Features.Common.DepartmentCommon.Queries
{
    public sealed record IsDepartmentCodeUniqueForUpdateQuery(Guid DepartmentId, Guid BranchId, string Code)
        : IRequest<RequestResult<bool>>;
}

