using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;

namespace HRManagementSystem.Features.CountryManagement.GetAllCountries.Queries
{
    public sealed record GetAllCountriesQuery()
     : IRequest<RequestResult<List<ViewCountryDto>>>;
}
