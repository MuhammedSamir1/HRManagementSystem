using HRManagementSystem.Features.Common.PayrollCommon;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.GetPayrollItemById.Queries;

namespace HRManagementSystem.Features.Configurations.PayrollManagement.PayrollItemManagement.GetPayrollItemById
{
    public class GetPayrollItemByIdEndPoint : BaseEndPoint<int, ResponseViewModel<PayrollItemDto>>
    {
        public GetPayrollItemByIdEndPoint(EndPointBaseParameters<int> parameters)
            : base(parameters) { }

        [HttpGet("payroll-items/{id:int}")] // GET /api/payroll/payroll-items/5
        public async Task<ResponseViewModel<PayrollItemDto>> GetItemById([FromRoute] int id, CancellationToken ct)
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
