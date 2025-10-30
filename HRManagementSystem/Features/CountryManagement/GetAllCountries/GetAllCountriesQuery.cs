using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;

namespace HRManagementSystem.Features.CountryManagement.GetAllCountries
{
    public sealed record GetAllCountriesQuery()
     : IRequest<ResponseViewModel<List<ViewCountryDto>>>;
}
