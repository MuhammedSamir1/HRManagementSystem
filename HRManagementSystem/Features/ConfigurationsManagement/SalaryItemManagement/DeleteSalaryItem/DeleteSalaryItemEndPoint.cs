using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.DeleteSalaryItem.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.DeleteSalaryItem
{
    public class DeleteSalaryItemEndPoint : EndPointBase<DeleteSalaryItemViewModel, DeleteSalaryItemCommand, RequestResult<string>>
    {
        private readonly IMediator _mediator;

        public DeleteSalaryItemEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpDelete("api/SalaryItem/Delete")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<string>>>> HandleAsync([FromQuery] DeleteSalaryItemViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<DeleteSalaryItemViewModel, DeleteSalaryItemCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
