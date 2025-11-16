namespace HRManagementSystem.Features.Common.AddressManagement.StateCommon.ViewModels
{
    public sealed record ViewStateCityViewModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
    }
}

