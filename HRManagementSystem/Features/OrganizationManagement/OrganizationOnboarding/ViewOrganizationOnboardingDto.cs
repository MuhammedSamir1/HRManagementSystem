namespace HRManagementSystem.Features.OrganizationManagement.OrganizationOnboarding;

public sealed class ViewOrganizationOnboardingDto
{
    public int OrganizationId { get; set; }
    public List<CompanyNodeDto> Companies { get; set; } = new();
}

public sealed class CompanyNodeDto
{
    public int CompanyId { get; set; }
    public List<BranchNodeDto> Branches { get; set; } = new();
}

public sealed class BranchNodeDto
{
    public int BranchId { get; set; }
    public List<DepartmentNodeDto> Departments { get; set; } = new();
}

public sealed class DepartmentNodeDto
{
    public int DepartmentId { get; set; }
    public List<TeamNodeDto> Teams { get; set; } = new();
}

public sealed class TeamNodeDto
{
    public int TeamId { get; set; }
}

