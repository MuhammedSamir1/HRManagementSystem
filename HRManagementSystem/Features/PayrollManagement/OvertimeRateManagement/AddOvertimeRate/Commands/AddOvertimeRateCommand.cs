using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.PayrollManagement.OvertimeRateManagement.AddOvertimeRate.Commands
{
    public sealed record AddOvertimeRateCommand(
         string Name,
         decimal RateFactor,
         string Description) : IRequest<RequestResult<OvertimeRateDto>>;
}
