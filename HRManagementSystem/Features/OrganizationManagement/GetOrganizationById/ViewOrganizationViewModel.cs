using HRManagementSystem.Features.Common.AddressManagement.GetAddressDtosAndVms.ViewModels;
using HRManagementSystem.Features.Common.CurrencyManagement.GetCurrencyDtosAndVms.ViewModels;

namespace HRManagementSystem.Features.OrganizationManagement.GetOrganizationById
{
    public sealed record ViewOrganizationViewModel
    {
        public string Name { get; init; } = default!;
        public string? LegalName { get; init; }
        public string? Industry { get; init; }
        public string? Descreption { get; init; }
        public DateTime? DefaultTimezone { get; init; }
        public ViewOrganizationCurrencyViewModel? Currency { get; init; }
        public ViewOrganizationAddressViewModel Address { get; init; } = default!;
    }
}
