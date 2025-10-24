﻿namespace HRManagementSystem.Features.Common.AddressManagement.StateCommon.ViewModels
{
    public sealed record ViewStateCityViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
    }
}
