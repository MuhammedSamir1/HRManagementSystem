namespace HRManagementSystem.Features.Common.DepartmentCommon.Queries
{
    public sealed record IsDepartmentCodeUniqueQuery(Guid BranchId, string Code) : IRequest<RequestResult<bool>>;
}

