using HRManagementSystem.Features.Common.PayrollCommon;
using HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.AddPayrollItem.Commands;
using HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.AddPayrollItem.ViewModels;

namespace HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.AddPayrollItem
{
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
