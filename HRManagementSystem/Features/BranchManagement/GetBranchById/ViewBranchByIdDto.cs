using HRManagementSystem.Features.Common.AddressManagement.GetAddressDtosAndVms.Dtos;

namespace HRManagementSystem.Features.BranchManagement.GetBranchById
{
    public sealed record ViewBranchByIdDto
    {
        public string Name { get; init; } = default!;
        public string? Description { get; init; }
        public string Code { get; init; } = default!;
        public ViewBranchAddressDto Address { get; init; } = default!;
    }
}
