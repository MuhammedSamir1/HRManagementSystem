using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using MediatR;

namespace HRManagementSystem.Features.CountryManagement.UpdateCountry.Commands
{
    public sealed record UpdateCountryCommand(int Id, string Iso2, string Iso3, string Name)
      : IRequest<ResponseViewModel<ViewCountryDto>>;

}
