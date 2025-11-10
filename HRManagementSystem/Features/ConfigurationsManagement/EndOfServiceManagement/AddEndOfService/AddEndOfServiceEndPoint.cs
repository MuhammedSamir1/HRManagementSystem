using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.AddEndOfService.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.AddEndOfService
{
    public class AddEndOfServiceEndPoint : EndPointBase<AddEndOfServiceViewModel, AddEndOfServiceCommand, RequestResult<CreatedIdDto>>
    {
        private readonly IMediator _mediator;

        public AddEndOfServiceEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpPost("api/EndOfService/Add")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<CreatedIdDto>>>> HandleAsync([FromBody] AddEndOfServiceViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<AddEndOfServiceViewModel, AddEndOfServiceCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
