namespace HRManagementSystem.Features.ScopeManagement.GetAllScopes
{
    public sealed record ViewScopeDto(
        Guid Id,
        Guid OrganizationId,
        Guid CompanyId,
        Guid BranchId,
        Guid DepartmentId,
        Guid TeamId);
}

