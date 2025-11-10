using HRManagementSystem.Features.Common.PayrollCommon;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.UpdatePayrollItem.Commands;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.UpdatePayrollItem.ViewModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.UpdatePayrollItem
{
    public class UpdatePayrollItemEndPoint : BaseEndPoint<UpdatePayrollItemViewModel, ResponseViewModel<PayrollItemDto>>
    {
        public UpdatePayrollItemEndPoint(EndPointBaseParameters<UpdatePayrollItemViewModel> parameters)
            : base(parameters) { }

        [HttpPut("payroll-items")] // PUT /api/payroll/payroll-items
        public async Task<ResponseViewModel<PayrollItemDto>> UpdateItem([FromBody] UpdatePayrollItemViewModel model, CancellationToken ct)
        {

            var command = _mapper.Map<UpdatePayrollItemCommand>(model);


            var result = await _mediator.Send(command, ct);


            if (!result.isSuccess)
            {
                return ResponseViewModel<PayrollItemDto>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<PayrollItemDto>.Success(result.data, result.message);
        }
    }
}
