using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.ViewModels;
using HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.ViewModels;

namespace HRManagementSystem.Features.OrganizationManagement.OrganizationOnboarding
{
    public class OrganizationOnboardingRequestViewModel
    {
        public string Name { get; set; } = default!;
        public string? LegalName { get; set; }
        public string? Industry { get; set; }
        public string? Description { get; set; }
        public DateTime? DefaultTimezone { get; set; }

        public AddOrganizationCurrencyViewModel? Currency { get; set; }
        public AddOrganizationAddressViewModel? Address { get; set; }

        public List<CompanyRequestViewModel>? Companies { get; set; }
    }

    public class CompanyRequestViewModel
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }

        public List<BranchRequestViewModel>? Branches { get; set; }
    }

    public class BranchRequestViewModel
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Code { get; set; } = default!;
        public AddBranchAddressViewModel? Address { get; set; }

        public List<DepartmentRequestViewModel>? Departments { get; set; }
    }

    public class DepartmentRequestViewModel
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Code { get; set; } = default!;

        public List<TeamRequestViewModel>? Teams { get; set; }
    }

    public class TeamRequestViewModel
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Code { get; set; } = default!;
    }
}
