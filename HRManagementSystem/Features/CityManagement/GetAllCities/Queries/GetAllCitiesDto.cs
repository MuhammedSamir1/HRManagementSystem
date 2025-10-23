namespace HRManagementSystem.Features.Common.AddressManagement.GetAllCities.Dtos
{
    public sealed record GetAllCitiesDto(
        int Id,
        string Name,
        int StateId
    );
}