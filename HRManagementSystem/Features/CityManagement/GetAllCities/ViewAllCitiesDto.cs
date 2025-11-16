namespace HRManagementSystem.Features.CityManagement.GetAllCities
{
    public sealed record ViewAllCitiesDto(
        Guid Id,
        string Name,
        Guid StateId
    );
}
