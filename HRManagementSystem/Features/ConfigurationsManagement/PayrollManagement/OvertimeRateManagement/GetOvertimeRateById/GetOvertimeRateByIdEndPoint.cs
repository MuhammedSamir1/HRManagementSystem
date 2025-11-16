using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.GetOvertimeRateById
{
    public class GetOvertimeRateByIdEndPoint
        : BaseEndPoint<Guid, ResponseViewModel<OvertimeRateDto>>
    {
        public GetOvertimeRateByIdEndPoint(EndPointBaseParameters<Guid> parameters)
            : base(parameters) { }

        [HttpGet("payroll/overtime-rates/{id:int}")] // ????: GET /api/payroll/overtime-rates/5
        public async Task<ResponseViewModel<OvertimeRateDto>> GetOvertimeRateById([FromRoute] Guid id, CancellationToken ct)
        {
            var query = new Queries.GetOvertimeRateByIdQuery(id);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
                return ResponseViewModel<OvertimeRateDto>.Failure(result.message, result.errorCode);

            return ResponseViewModel<OvertimeRateDto>.Success(result.data, result.message);
        }
    }
}

