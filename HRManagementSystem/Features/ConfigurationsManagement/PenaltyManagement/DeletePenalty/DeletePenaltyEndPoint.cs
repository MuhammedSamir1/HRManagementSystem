using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.DeletePenalty.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.DeletePenalty
{
    public class DeletePenaltyEndPoint : EndPointBase<DeletePenaltyViewModel, DeletePenaltyCommand, RequestResult<string>>
    {
        private readonly IMediator _mediator;

        public DeletePenaltyEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpDelete("api/Penalty/Delete")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<string>>>> HandleAsync([FromQuery] DeletePenaltyViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<DeletePenaltyViewModel, DeletePenaltyCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
