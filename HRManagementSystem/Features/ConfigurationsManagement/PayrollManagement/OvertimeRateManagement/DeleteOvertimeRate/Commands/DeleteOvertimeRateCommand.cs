namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.DeleteOvertimeRate.Commands
{
    public sealed record DeleteOvertimeRateCommand(int Id) : IRequest<RequestResult<bool>>;

}
