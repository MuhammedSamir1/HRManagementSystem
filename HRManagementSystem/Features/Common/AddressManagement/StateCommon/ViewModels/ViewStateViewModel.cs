namespace HRManagementSystem.Features.Common.AddressManagement.StateCommon.ViewModels
{
    public sealed record ViewStateViewModel
    {
        public Guid Id { get; init; }
        public string Code { get; init; } = default!;
        public string Name { get; init; } = default!;
        public ViewStateCountryViewModel Country { get; init; } = default!;
        public ICollection<ViewStateCityViewModel> Cities { get; init; } = new HashSet<ViewStateCityViewModel>();
    }


}

