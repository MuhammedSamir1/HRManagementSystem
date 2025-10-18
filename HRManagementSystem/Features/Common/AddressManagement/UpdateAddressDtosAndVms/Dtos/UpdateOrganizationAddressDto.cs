namespace HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.Dtos
{
    public sealed record UpdateOrganizationAddressDto(int CountryId, int StateId, int CityId, string? Street, string? ZipCode);
}
