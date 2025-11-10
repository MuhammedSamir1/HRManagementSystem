using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.DeleteBonus.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.DeleteBonus
{
    public class DeleteBonusEndPoint : EndPointBase<DeleteBonusViewModel, DeleteBonusCommand, RequestResult<string>>
    {
        private readonly IMediator _mediator;

        public DeleteBonusEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpDelete("api/Bonus/Delete")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<string>>>> HandleAsync([FromQuery] DeleteBonusViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<DeleteBonusViewModel, DeleteBonusCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
