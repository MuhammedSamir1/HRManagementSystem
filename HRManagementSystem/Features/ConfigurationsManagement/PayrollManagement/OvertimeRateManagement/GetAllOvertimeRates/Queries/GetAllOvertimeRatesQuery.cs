using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.GetAllOvertimeRates.Queries
{
    public record GetAllOvertimeRatesQuery : GetPagedListQueryBase<OvertimeRateDto>
    {
        public bool IncludeInactive { get; init; } = false;
        public OvertimeDayType? DayType { get; init; }
        public string? Search { get; init; }
    }
}
