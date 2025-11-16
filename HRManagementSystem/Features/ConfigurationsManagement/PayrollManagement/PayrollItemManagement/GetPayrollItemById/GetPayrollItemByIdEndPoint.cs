using HRManagementSystem.Features.Common.PayrollCommon;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.GetPayrollItemById.Queries;

namespace HRManagementSystem.Features.Configurations.PayrollManagement.PayrollItemManagement.GetPayrollItemById
{
    [ApiGroup("Configurations Management", "Payroll Management")]
    public class GetPayrollItemByIdEndPoint : BaseEndPoint<Guid, ResponseViewModel<PayrollItemDto>>
    {
        public GetPayrollItemByIdEndPoint(EndPointBaseParameters<Guid> parameters)
            : base(parameters) { }

        [HttpGet("payroll-items/{id:int}")] // GET /api/payroll/payroll-items/5
        public async Task<ResponseViewModel<PayrollItemDto>> GetItemById([FromRoute] Guid id, CancellationToken ct)
        {
            var query = new GetPayrollItemByIdQuery(id);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<PayrollItemDto>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<PayrollItemDto>.Success(result.data, result.message);
        }
    }
}




