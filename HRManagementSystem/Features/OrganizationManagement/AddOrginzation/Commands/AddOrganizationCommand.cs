using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.Dtos;
using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.OrganizationManagement.AddOrginzation.Commands
{
    public record AddOrganizationCommand(string Name, string? LegalName, string? Industry, string? Description,
        DateTime? DefaultTimezone, AddOrganizationCurrencyDto CurrencyDto,
        AddOrganizationAddressDto AddressDto) : IRequest<RequestResult<CreatedIdDto>>;


}
