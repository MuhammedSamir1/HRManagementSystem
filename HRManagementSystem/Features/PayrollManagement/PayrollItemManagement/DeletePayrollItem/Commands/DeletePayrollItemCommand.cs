using HRManagementSystem.Common.Views.Response;

namespace HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.DeletePayrollItem.Commands
{
    public sealed record DeletePayrollItemCommand(int Id) : IRequest<RequestResult<bool>>;
}
