using HRManagementSystem.Common.Views.Response;
using MediatR;

namespace HRManagementSystem.Features.CityManagement.HasAssignedCities
{
    public sealed record HasAssignedCitiesQuery(int CountryId) : IRequest<RequestResult<bool>>;
}
