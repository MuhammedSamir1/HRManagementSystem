using HRManagementSystem.Features.Common.AddressManagement.GetAddressDtosAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.GetCurrencyDtosAndVms.Dtos;

namespace HRManagementSystem.Features.OrganizationManagement.GetOrganizationById
{
    public sealed record ViewOrganizationDto
    {
        public string Name { get; init; } = default!;
        public string? LegalName { get; init; }
        public string? Industry { get; init; }
        public string? Descreption { get; init; }
        public DateTime? DefaultTimezone { get; init; }
        public ViewOrganizationCurrencyDto? Currency { get; init; }
        public ViewOrganizationAddressDto Address { get; init; } = default!;
    }
}
