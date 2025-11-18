namespace HRManagementSystem.Features.ScopeManagement.GetAllScopes
{
    public sealed record ViewScopeViewModel(
        Guid Id,
        Guid OrganizationId,
        Guid CompanyId,
        Guid BranchId,
        Guid DepartmentId,
        Guid TeamId);
}

