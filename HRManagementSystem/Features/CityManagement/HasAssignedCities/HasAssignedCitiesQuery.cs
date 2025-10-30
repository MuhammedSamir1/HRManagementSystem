namespace HRManagementSystem.Features.CityManagement.HasAssignedCities
{
    public sealed record HasAssignedCitiesQuery(int CountryId) : IRequest<RequestResult<bool>>;
}
