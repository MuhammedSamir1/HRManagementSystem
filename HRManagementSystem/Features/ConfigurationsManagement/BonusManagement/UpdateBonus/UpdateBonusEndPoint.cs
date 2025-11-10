using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.UpdateBonus.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.UpdateBonus
{
    public class UpdateBonusEndPoint : EndPointBase<UpdateBonusViewModel, UpdateBonusCommand, RequestResult<string>>
    {
        private readonly IMediator _mediator;

        public UpdateBonusEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpPut("api/Bonus/Update")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<string>>>> HandleAsync([FromBody] UpdateBonusViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<UpdateBonusViewModel, UpdateBonusCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
