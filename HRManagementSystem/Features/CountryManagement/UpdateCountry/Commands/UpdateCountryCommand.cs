using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;

namespace HRManagementSystem.Features.CountryManagement.UpdateCountry.Commands
{
    public sealed record UpdateCountryCommand(Guid Id, string Iso2, string Iso3, string Name)
      : IRequest<RequestResult<ViewCountryDto>>;

}

