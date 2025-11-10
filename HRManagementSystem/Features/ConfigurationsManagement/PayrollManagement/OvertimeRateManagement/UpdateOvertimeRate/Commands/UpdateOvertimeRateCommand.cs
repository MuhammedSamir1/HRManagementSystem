using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.UpdateOvertimeRate.Commands
{
    public sealed record UpdateOvertimeRateCommand(
         int Id,
         string Name,
         decimal RateFactor,
         string Description,
         bool IsActive) : IRequest<RequestResult<OvertimeRateDto>>;
}
