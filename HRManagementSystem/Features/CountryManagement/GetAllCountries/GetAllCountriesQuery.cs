using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using MediatR;

namespace HRManagementSystem.Features.CountryManagement.GetAllCountries
{
    public sealed record GetAllCountriesQuery()
     : IRequest<ResponseViewModel<List<ViewCountryDto>>>;
}
