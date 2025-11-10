using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.AddPenalty.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.AddPenalty
{
    public class AddPenaltyEndPoint : BaseEndPoint<AddPenaltyViewModel, ResponseViewModel<int>>
    {
        public AddPenaltyEndPoint(EndPointBaseParameters<AddPenaltyViewModel> parameters) : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<int>> AddPenalty([FromBody] AddPenaltyViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<AddPenaltyCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<int>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<int>.Success(result.data, result.message);
        }
    }
}
