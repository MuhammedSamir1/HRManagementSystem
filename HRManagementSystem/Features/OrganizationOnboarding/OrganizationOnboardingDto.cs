using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.ViewModels;
using HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.ViewModels;

namespace HRManagementSystem.Features.OrganizationOnboarding
{
    public class OrganizationOnboardingDto
    {
        public string Name { get; set; } = default!;
        public string? LegalName { get; set; }
        public string? Industry { get; set; }
        public string? Description { get; set; }
        public DateTime? DefaultTimezone { get; set; }

        public AddOrganizationCurrencyViewModel? Currency { get; set; }
        public AddOrganizationAddressViewModel? Address { get; set; }

        public List<CompanyDto>? Companies { get; set; }
    }

    public class CompanyDto
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
        public List<BranchDto>? Branches { get; set; }
    }

    public class BranchDto
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Code { get; set; } = default!;
        public AddBranchAddressViewModel? Address { get; set; }

        public List<DepartmentDto>? Departments { get; set; }
    }

    public class DepartmentDto
    {
        public int BranchId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Code { get; set; } = default!;
        public List<TeamDto>? Teams { get; set; }
    }

    public class TeamDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Code { get; set; } = default!;
    }
}
