using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.AddPayrollItem.Commands
{
    public sealed record AddPayrollItemCommand(
      string Name,
      PayrollItemType Type,
      CalculationType CalculationType,
      decimal Value,
      bool IsStatutory) : IRequest<RequestResult<PayrollItemDto>>;
}
