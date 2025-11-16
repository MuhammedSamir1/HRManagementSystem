using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.UpdatePenalty.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.UpdatePenalty
{
    [ApiGroup("Configurations Management", "Penalty Management")]
    public class UpdatePenaltyEndPoint : BaseEndPoint<UpdatePenaltyViewModel, ResponseViewModel<bool>>
    {
        public UpdatePenaltyEndPoint(EndPointBaseParameters<UpdatePenaltyViewModel> parameters) : base(parameters) { }

        [HttpPut]
        public async Task<ResponseViewModel<bool>> UpdatePenalty([FromBody] UpdatePenaltyViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<UpdatePenaltyCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}



