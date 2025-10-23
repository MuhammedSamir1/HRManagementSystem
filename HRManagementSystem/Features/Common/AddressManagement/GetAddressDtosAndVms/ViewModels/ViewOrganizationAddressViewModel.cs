using HRManagementSystem.Features.Common.AddressManagement.CityCommon.ViewModels;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.ViewModels;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.ViewModels;

namespace HRManagementSystem.Features.Common.AddressManagement.GetAddressDtosAndVms.ViewModels
{
    public sealed record ViewOrganizationAddressViewModel(ViewCountryViewModel Country, ViewCityViewModel City,
        ViewStateViewModel State, string? Street, string? ZipCode);
}
