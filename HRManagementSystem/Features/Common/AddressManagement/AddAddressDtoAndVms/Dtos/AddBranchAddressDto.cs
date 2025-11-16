namespace HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos
{
    public sealed record AddBranchAddressDto(Guid CountryId, Guid StateId, Guid CityId, string? Street, string? ZipCode);
}

