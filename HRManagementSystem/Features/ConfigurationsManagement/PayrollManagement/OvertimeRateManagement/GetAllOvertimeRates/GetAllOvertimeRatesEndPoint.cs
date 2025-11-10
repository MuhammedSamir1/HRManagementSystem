using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.Common.PayrollCommon;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.GetAllOvertimeRates.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.GetAllOvertimeRates
{
    public class GetAllOvertimeRatesEndPoint : BaseEndPoint<GetAllOvertimeRatesViewModel, ResponseViewModel<object>>
    {
        public GetAllOvertimeRatesEndPoint(EndPointBaseParameters<GetAllOvertimeRatesViewModel> parameters) : base(parameters) { }

        [HttpGet("overtime-rates")]
        public async Task<ResponseViewModel<PagedList<OvertimeRateDto>>> GetAllOvertimeRates([FromQuery] GetAllOvertimeRatesViewModel model, CancellationToken ct)
        {
            var query = _mapper.Map<GetAllOvertimeRatesQuery>(model);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<PagedList<OvertimeRateDto>>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<PagedList<OvertimeRateDto>>.Success(result.data);
        }
    }
}

