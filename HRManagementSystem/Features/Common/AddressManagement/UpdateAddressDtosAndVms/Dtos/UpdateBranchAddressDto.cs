namespace HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.Dtos
{
    public sealed record UpdateBranchAddressDto(int CountryId, int StateId, int CityId, string? Street, string? ZipCode);
}
