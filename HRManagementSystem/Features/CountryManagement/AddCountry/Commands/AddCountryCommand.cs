using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;

namespace HRManagementSystem.Features.CountryManagement.AddCountry.Commands
{
    public sealed record AddCountryCommand(string Iso2, string Iso3, string Name)
      : IRequest<RequestResult<ViewCountryDto>>;
}
