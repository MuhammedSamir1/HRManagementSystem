namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.GetAllOvertimeRates
{
    public sealed record GetAllOvertimeRatesViewModel(
        int PageNumber = 1,
        int PageSize = 10,
        bool IncludeInactive = false,
        OvertimeDayType? DayType = null,
        string? Search = null,
        string? SortBy = null,
        string? SortDirection = "asc");
}

