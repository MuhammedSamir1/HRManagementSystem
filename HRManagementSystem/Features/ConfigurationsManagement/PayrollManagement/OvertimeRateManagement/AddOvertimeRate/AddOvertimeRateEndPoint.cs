using HRManagementSystem.Features.Common.PayrollCommon;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.AddOvertimeRate.Commands;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.AddOvertimeRate.ViewModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.AddOvertimeRate
{
    [ApiGroup("Configurations Management", "Payroll Management")]
    public class AddOvertimeRateEndPoint : BaseEndPoint<AddOvertimeRateViewModel, ResponseViewModel<OvertimeRateDto>>
    {
        public AddOvertimeRateEndPoint(EndPointBaseParameters<AddOvertimeRateViewModel> parameters)
            : base(parameters) { }

        [HttpPost("overtime-rates")] // POST /api/payroll/overtime-rates
        public async Task<ResponseViewModel<OvertimeRateDto>> AddItem([FromBody] AddOvertimeRateViewModel model, CancellationToken ct)
        {
            // 1. Mapping ViewModel ??? Command
            var command = _mapper.Map<AddOvertimeRateCommand>(model);

            // 2. ????? Command
            var result = await _mediator.Send(command, ct);


            if (!result.isSuccess)
            {
                return ResponseViewModel<OvertimeRateDto>.Failure("Error in AddOvertimeRateEndPoint ", result.errorCode);
            }

            return ResponseViewModel<OvertimeRateDto>.Success(result.data, result.message);
        }
    }
}



