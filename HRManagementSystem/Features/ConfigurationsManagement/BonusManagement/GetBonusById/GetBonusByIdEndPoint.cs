using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetBonusById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetBonusById
{
    public class GetBonusByIdEndPoint : EndPointBase<GetBonusByIdViewModel, GetBonusByIdQuery, RequestResult<ViewBonusByIdDto>>
    {
        private readonly IMediator _mediator;

        public GetBonusByIdEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpGet("api/Bonus/GetById")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<ViewBonusByIdDto>>>> HandleAsync([FromQuery] GetBonusByIdViewModel viewModel, CancellationToken ct)
        {
            var query = _mapper.Map<GetBonusByIdViewModel, GetBonusByIdQuery>(viewModel);
            var result = await _mediator.Send(query, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
