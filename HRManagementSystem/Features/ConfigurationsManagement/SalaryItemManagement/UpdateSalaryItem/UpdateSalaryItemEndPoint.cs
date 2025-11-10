using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.UpdateSalaryItem.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.UpdateSalaryItem
{
    public class UpdateSalaryItemEndPoint : EndPointBase<UpdateSalaryItemViewModel, UpdateSalaryItemCommand, RequestResult<string>>
    {
        private readonly IMediator _mediator;

        public UpdateSalaryItemEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpPut("api/SalaryItem/Update")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<string>>>> HandleAsync([FromBody] UpdateSalaryItemViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<UpdateSalaryItemViewModel, UpdateSalaryItemCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
