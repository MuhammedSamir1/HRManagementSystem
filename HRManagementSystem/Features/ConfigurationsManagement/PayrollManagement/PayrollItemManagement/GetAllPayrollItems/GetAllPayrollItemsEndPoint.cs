using HRManagementSystem.Features.Common.PayrollCommon;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.GetAllPayrollItems.Queries;

namespace HRManagementSystem.Features.Configurations.PayrollManagement.PayrollItemManagement.GetAllPayrollItems
{
    public class GetAllPayrollItemsEndPoint : BaseEndPoint<object, ResponseViewModel<IEnumerable<PayrollItemDto>>>
    {
        // نستخدم object لأن الـ Query لا تحتاج أي مدخلات في هذه النسخة
        public GetAllPayrollItemsEndPoint(EndPointBaseParameters<object> parameters)
            : base(parameters) { }

        [HttpGet("payroll-items")] // GET /api/payroll/payroll-items
        public async Task<ResponseViewModel<IEnumerable<PayrollItemDto>>> GetAllItems(CancellationToken ct)
        {
            var query = new GetAllPayrollItemsQuery();
            var result = await _mediator.Send(query, ct);


            if (!result.isSuccess)
            {
                return ResponseViewModel<IEnumerable<PayrollItemDto>>.Failure("error occured while processing your request", result.errorCode);
            }

            return ResponseViewModel<IEnumerable<PayrollItemDto>>.Success(result.data, result.message);
        }
    }
}
