using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CountryManagement.UpdateCountry.Commands
{
    public sealed record UpdateCountryCommand(int Id, string Iso2, string Iso3, string Name)
      : IRequest<RequestResult<ViewCountryDto>>;

}
