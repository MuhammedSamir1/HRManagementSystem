using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using MediatR;

namespace HRManagementSystem.Features.CountryManagement.GetCountryById
{
    public sealed record GetCountryByIdQuery(int Id)
    : IRequest<ResponseViewModel<ViewCountryDto>>;
}
