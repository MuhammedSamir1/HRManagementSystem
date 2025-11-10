using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.AddBonus.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.AddBonus
{
    public class AddBonusEndPoint : EndPointBase<AddBonusViewModel, AddBonusCommand, RequestResult<CreatedIdDto>>
    {
        private readonly IMediator _mediator;

        public AddBonusEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpPost("api/Bonus/Add")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<CreatedIdDto>>>> HandleAsync([FromBody] AddBonusViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<AddBonusViewModel, AddBonusCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
