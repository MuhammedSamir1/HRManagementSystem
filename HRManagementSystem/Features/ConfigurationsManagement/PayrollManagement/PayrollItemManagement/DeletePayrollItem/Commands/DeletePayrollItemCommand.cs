namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.DeletePayrollItem.Commands
{
    public sealed record DeletePayrollItemCommand(int Id) : IRequest<RequestResult<bool>>;
}
