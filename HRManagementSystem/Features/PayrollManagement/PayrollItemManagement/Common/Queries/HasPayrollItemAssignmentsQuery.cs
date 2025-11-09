namespace HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.Common.Queries
{
    public sealed record HasPayrollItemAssignmentsQuery(int PayrollItemId)
      : IRequest<RequestResult<bool>>;
}
