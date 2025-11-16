namespace HRManagementSystem.Features.CityManagement.HasAssignedCities
{
    public sealed record HasAssignedCitiesQuery(Guid CountryId) : IRequest<RequestResult<bool>>;
}

