namespace HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos
{
    public sealed record AddOrganizationAddressDto(Guid CountryId, Guid StateId, Guid CityId, string? Street, string? ZipCode);
}

