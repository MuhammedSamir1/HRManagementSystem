using HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.DeletePayrollItem.Commands;
using HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.DeletePayrollItem.ViewModels;

namespace HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.DeletePayrollItem
{
    public class DeletePayrollItemEndPoint : BaseEndPoint<DeletePayrollItemViewModel, ResponseViewModel<bool>>
    {
        public DeletePayrollItemEndPoint(EndPointBaseParameters<DeletePayrollItemViewModel> parameters)
            : base(parameters) { }

        [HttpDelete("payroll-items/{id:int}")] // DELETE /api/payroll/payroll-items/5
        public async Task<ResponseViewModel<bool>> DeleteItem([FromRoute] int id, CancellationToken ct)
        {
       
            var command = new DeletePayrollItemCommand(id);

    
            var result = await _mediator.Send(command, ct);

     
            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(result.data, result.message);
        }
    }
}
