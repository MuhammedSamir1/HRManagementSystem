namespace HRManagementSystem.Features.CityManagement.GetCityById
{
    public sealed record GetCityByIdDto(
        int Id,
        string Name,
        int StateId
    );
}
