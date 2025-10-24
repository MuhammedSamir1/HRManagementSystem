using HRManagementSystem.Features.Common.AddressManagement.GetAddressDtosAndVms.Dtos;

namespace HRManagementSystem.Features.BranchManagement.GetAllBranches
{
    public sealed record ViewBranchDto
    {
        public string Name { get; init; } = default!;
        public string? Description { get; init; }
        public string Code { get; init; } = default!;
        public ViewBranchAddressDto Address { get; init; } = default!;
    }
}
