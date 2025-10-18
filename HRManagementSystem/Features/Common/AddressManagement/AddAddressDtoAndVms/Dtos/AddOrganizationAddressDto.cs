namespace HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos
{
    public sealed record AddOrganizationAddressDto(int CountryId, int StateId, int CityId, string? Street, string? ZipCode);
}
