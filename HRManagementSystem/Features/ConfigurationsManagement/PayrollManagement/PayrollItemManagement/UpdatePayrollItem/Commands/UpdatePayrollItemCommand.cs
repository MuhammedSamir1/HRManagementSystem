using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.UpdatePayrollItem.Commands
{
    public sealed record UpdatePayrollItemCommand(
     int Id,
     string Name,
     PayrollItemType Type,
     CalculationType CalculationType,
     decimal Value,
     bool IsStatutory) : IRequest<RequestResult<PayrollItemDto>>;
}
