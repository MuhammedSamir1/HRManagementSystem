namespace HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos
{
    public sealed record AddBranchAddressDto(int CountryId, int StateId, int CityId, string? Street, string? ZipCode);
}
