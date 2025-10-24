namespace HRManagementSystem.Features.CityManagement.GetAllCities
{
    public sealed record ViewAllCitiesDto(
        int Id,
        string Name,
        int StateId
    );
}