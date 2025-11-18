using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.Dtos;

namespace HRManagementSystem.Features.OrganizationManagement.OrganizationOnboarding
{
    public sealed class OrganizationOnboardingDto
    {
        public string Name { get; set; } = default!;
        public string? LegalName { get; set; }
        public string? Industry { get; set; }
        public string? Description { get; set; }
        public string? DefaultTimezone { get; set; }

        public AddOrganizationCurrencyDto? Currency { get; set; }
        public AddOrganizationAddressDto? Address { get; set; }

        public List<CompanyDto> Companies { get; set; } = new();
    }

    public sealed class CompanyDto
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
        public List<BranchDto>? Branches { get; set; }
    }

    public sealed class BranchDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Code { get; set; } = default!;
        public AddBranchAddressDto? Address { get; set; }

        public List<DepartmentDto>? Departments { get; set; }
    }

    public sealed class DepartmentDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Code { get; set; } = default!;
        public List<TeamDto>? Teams { get; set; }
    }

    public sealed class TeamDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Code { get; set; } = default!;
    }
}

