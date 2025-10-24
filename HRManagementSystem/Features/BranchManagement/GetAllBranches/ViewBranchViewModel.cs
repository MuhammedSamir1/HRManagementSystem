using HRManagementSystem.Features.Common.AddressManagement.GetAddressDtosAndVms.ViewModels;

namespace HRManagementSystem.Features.BranchManagement.GetAllBranches
{
    public sealed record ViewBranchViewModel
    {
        public string Name { get; init; } = default!;
        public string? Description { get; init; }
        public string Code { get; init; } = default!;
        public ViewBranchAddressViewModel Address { get; init; } = default!;
    }
}
