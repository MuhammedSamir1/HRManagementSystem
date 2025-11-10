namespace HRManagementSystem.Features.PayrollManagement.OvertimeRateManagement.DeleteOvertimeRate.Commands
{
    public sealed record DeleteOvertimeRateCommand(int Id) : IRequest<RequestResult<bool>>;

}
