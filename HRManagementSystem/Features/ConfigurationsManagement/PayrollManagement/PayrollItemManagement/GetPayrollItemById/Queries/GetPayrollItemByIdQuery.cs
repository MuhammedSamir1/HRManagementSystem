using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.GetPayrollItemById.Queries
{
    public sealed record GetPayrollItemByIdQuery(int Id) : IRequest<RequestResult<PayrollItemDto>>;
}
