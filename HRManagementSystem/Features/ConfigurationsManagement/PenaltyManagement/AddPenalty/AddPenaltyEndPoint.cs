using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.AddPenalty.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.AddPenalty
{
    public class AddPenaltyEndPoint : EndPointBase<AddPenaltyViewModel, AddPenaltyCommand, RequestResult<CreatedIdDto>>
    {
        private readonly IMediator _mediator;

        public AddPenaltyEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpPost("api/Penalty/Add")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<CreatedIdDto>>>> HandleAsync([FromBody] AddPenaltyViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<AddPenaltyViewModel, AddPenaltyCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
