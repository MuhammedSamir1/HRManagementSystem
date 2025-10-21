using HRManagementSystem.Features.Common.AddressManagement.CityCommon.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.Dtos;

namespace HRManagementSystem.Features.Common.AddressManagement.GetAddressDtosAndVms.Dtos
{
    public sealed record ViewOrganizationAddressDto(ViewCountryDto Country, ViewCityDto City,
        ViewStateDto State, string? Street, string? ZipCode);
}
