using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.AddPenalty.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.AddPenalty
{
    [ApiGroup("Configurations Management", "Penalty Management")]
    public class AddPenaltyEndPoint : BaseEndPoint<AddPenaltyViewModel, ResponseViewModel<Guid>>
    {
        public AddPenaltyEndPoint(EndPointBaseParameters<AddPenaltyViewModel> parameters) : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<Guid>> AddPenalty([FromBody] AddPenaltyViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<AddPenaltyCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<Guid>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<Guid>.Success(result.data, result.message);
        }
    }
}




