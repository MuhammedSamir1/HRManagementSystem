using HRManagementSystem.Features.Common.PayrollCommon;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.UpdateOvertimeRate.Commands;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.UpdateOvertimeRate.ViewModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.UpdateOvertimeRate
{
    public class UpdateOvertimeRateEndPoint : BaseEndPoint<UpdateOvertimeRateViewModel, ResponseViewModel<OvertimeRateDto>>
    {
        public UpdateOvertimeRateEndPoint(EndPointBaseParameters<UpdateOvertimeRateViewModel> parameters)
            : base(parameters) { }

        [HttpPut("overtime-rates")] // PUT /api/payroll/overtime-rates
        public async Task<ResponseViewModel<OvertimeRateDto>> UpdateItem([FromBody] UpdateOvertimeRateViewModel model, CancellationToken ct)
        {

            var command = _mapper.Map<UpdateOvertimeRateCommand>(model);


            var result = await _mediator.Send(command, ct);


            if (!result.isSuccess)
            {
                return ResponseViewModel<OvertimeRateDto>.Failure("Error in updating overtime rate ", result.errorCode);
            }

            return ResponseViewModel<OvertimeRateDto>.Success(result.data, result.message);
        }
    }
}
