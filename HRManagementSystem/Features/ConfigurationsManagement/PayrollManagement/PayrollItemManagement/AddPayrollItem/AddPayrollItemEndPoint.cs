using HRManagementSystem.Features.Common.PayrollCommon;
using HRManagementSystem.Features.Configurations.PayrollManagement.PayrollItemManagement.AddPayrollItem.ViewModels;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.AddPayrollItem.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.AddPayrollItem
{
    [ApiGroup("Configurations Management", "Payroll Management")]
    public class AddPayrollItemEndPoint : BaseEndPoint<AddPayrollItemViewModel, ResponseViewModel<PayrollItemDto>>
    {
        public AddPayrollItemEndPoint(EndPointBaseParameters<AddPayrollItemViewModel> parameters)
            : base(parameters) { }

        [HttpPost("payroll-items")] // POST /api/payroll/payroll-items
        public async Task<ResponseViewModel<PayrollItemDto>> AddItem([FromBody] AddPayrollItemViewModel model, CancellationToken ct)
        {

            var command = _mapper.Map<AddPayrollItemCommand>(model);


            var result = await _mediator.Send(command, ct);


            if (!result.isSuccess)
            {
                return ResponseViewModel<PayrollItemDto>.Failure(result.message, result.errorCode);
            }


            return ResponseViewModel<PayrollItemDto>.Success(result.data, result.message);
        }
    }
}



