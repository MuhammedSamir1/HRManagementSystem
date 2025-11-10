using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.DeleteEndOfService.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.DeleteEndOfService
{
    public class DeleteEndOfServiceEndPoint : EndPointBase<DeleteEndOfServiceViewModel, DeleteEndOfServiceCommand, RequestResult<string>>
    {
        private readonly IMediator _mediator;

        public DeleteEndOfServiceEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpDelete("api/EndOfService/Delete")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<string>>>> HandleAsync([FromQuery] DeleteEndOfServiceViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<DeleteEndOfServiceViewModel, DeleteEndOfServiceCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
