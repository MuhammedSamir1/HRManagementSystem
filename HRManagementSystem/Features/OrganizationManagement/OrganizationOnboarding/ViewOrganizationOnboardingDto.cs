namespace HRManagementSystem.Features.OrganizationManagement.OrganizationOnboarding;

public sealed class ViewOrganizationOnboardingDto
{
    public Guid OrganizationId { get; set; }
    public List<CompanyNodeDto> Companies { get; set; } = new();
}

public sealed class CompanyNodeDto
{
    public Guid CompanyId { get; set; }
    public Guid ScopeId { get; set; }
    public List<BranchNodeDto> Branches { get; set; } = new();
}

public sealed class BranchNodeDto
{
    public Guid BranchId { get; set; }
    public Guid ScopeId { get; set; }
    public List<DepartmentNodeDto> Departments { get; set; } = new();
}

public sealed class DepartmentNodeDto
{
    public Guid DepartmentId { get; set; }
    public Guid ScopeId { get; set; }
    public List<TeamNodeDto> Teams { get; set; } = new();
}

public sealed class TeamNodeDto
{
    public Guid TeamId { get; set; }
    public Guid ScopeId { get; set; }
}


