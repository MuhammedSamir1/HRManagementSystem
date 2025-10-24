using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using MediatR;

namespace HRManagementSystem.Features.CountryManagement.AddCountry.Commands
{
    public sealed record AddCountryCommand(string Iso2, string Iso3, string Name)
      : IRequest<RequestResult<ViewCountryDto>>;
}
