namespace HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.Dtos
{
    public sealed record UpdateBranchAddressDto(Guid CountryId, Guid StateId, Guid CityId, string? Street, string? ZipCode);
}

