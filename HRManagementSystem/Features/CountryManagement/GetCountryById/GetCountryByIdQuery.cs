using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;

namespace HRManagementSystem.Features.CountryManagement.GetCountryById
{
    public sealed record GetCountryByIdQuery(Guid Id)
    : IRequest<ResponseViewModel<ViewCountryDto>>;
}

