using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.UpdateEndOfService.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.UpdateEndOfService
{
    public class UpdateEndOfServiceEndPoint : EndPointBase<UpdateEndOfServiceViewModel, UpdateEndOfServiceCommand, RequestResult<string>>
    {
        private readonly IMediator _mediator;

        public UpdateEndOfServiceEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpPut("api/EndOfService/Update")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<string>>>> HandleAsync([FromBody] UpdateEndOfServiceViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<UpdateEndOfServiceViewModel, UpdateEndOfServiceCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
