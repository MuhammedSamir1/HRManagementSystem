namespace HRManagementSystem.Features.ScopeManagement.GetScopeById
{
    public sealed record ViewScopeByIdDto(
        Guid Id,
        Guid OrganizationId,
        Guid CompanyId,
        Guid BranchId,
        Guid DepartmentId,
        Guid TeamId);
}

