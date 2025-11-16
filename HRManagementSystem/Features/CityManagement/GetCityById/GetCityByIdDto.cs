namespace HRManagementSystem.Features.CityManagement.GetCityById
{
    public sealed record GetCityByIdDto(
        Guid Id,
        string Name,
        Guid StateId
    );
}

