using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.AddSalaryItem.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.AddSalaryItem
{
    public class AddSalaryItemEndPoint : EndPointBase<AddSalaryItemViewModel, AddSalaryItemCommand, RequestResult<CreatedIdDto>>
    {
        private readonly IMediator _mediator;

        public AddSalaryItemEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpPost("api/SalaryItem/Add")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<CreatedIdDto>>>> HandleAsync([FromBody] AddSalaryItemViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<AddSalaryItemViewModel, AddSalaryItemCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
