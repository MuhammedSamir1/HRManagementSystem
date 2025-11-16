namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.DeletePayrollItem.Commands
{
    public sealed record DeletePayrollItemCommand(Guid Id) : IRequest<RequestResult<bool>>;
}

