namespace HRManagementSystem.Features.Common.AddressManagement.CityByIdDto.Dtos
{
    public sealed record GetCityByIdDto(
        int Id,
        string Name,
        int StateId
    );
}
