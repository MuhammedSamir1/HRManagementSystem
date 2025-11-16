namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.Common.Queries
{
    public sealed record HasPayrollItemAssignmentsQuery(Guid PayrollItemId)
      : IRequest<RequestResult<bool>>;
}

