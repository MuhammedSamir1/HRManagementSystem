namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.DeleteOvertimeRate.Commands
{
    public sealed record DeleteOvertimeRateCommand(Guid Id) : IRequest<RequestResult<bool>>;

}

