namespace HRManagementSystem.Features.Common.AddressManagement.AddAddressDtos.Dtos
{
    public sealed record AddOrganizationAddressDto(int CountryId, int StateId, int CityId, string? Street, string? ZipCode);
}
