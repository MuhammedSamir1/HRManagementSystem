using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.GetPayrollItemById.Queries
{
    public sealed record GetPayrollItemByIdQuery(Guid Id) : IRequest<RequestResult<PayrollItemDto>>;
}

