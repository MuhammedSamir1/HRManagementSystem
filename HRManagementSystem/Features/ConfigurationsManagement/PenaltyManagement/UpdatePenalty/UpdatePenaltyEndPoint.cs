using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.UpdatePenalty.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.UpdatePenalty
{
    public class UpdatePenaltyEndPoint : EndPointBase<UpdatePenaltyViewModel, UpdatePenaltyCommand, RequestResult<string>>
    {
        private readonly IMediator _mediator;

        public UpdatePenaltyEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpPut("api/Penalty/Update")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<string>>>> HandleAsync([FromBody] UpdatePenaltyViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<UpdatePenaltyViewModel, UpdatePenaltyCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
