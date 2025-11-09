using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.GetAllPayrollItems.Queries
{
    public sealed record GetAllPayrollItemsQuery() : IRequest<RequestResult<IEnumerable<PayrollItemDto>>>;
}
