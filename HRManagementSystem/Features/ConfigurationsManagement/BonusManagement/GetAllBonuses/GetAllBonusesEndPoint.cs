using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetAllBonuses.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetAllBonuses
{
    public class GetAllBonusesEndPoint : EndPointBase<GetAllBonusesViewModel, GetAllBonusesQuery, RequestResult<PagedList<ViewBonusDto>>>
    {
        private readonly IMediator _mediator;

        public GetAllBonusesEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpGet("api/Bonus/GetAll")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<PagedList<ViewBonusDto>>>>> HandleAsync([FromQuery] GetAllBonusesViewModel viewModel, CancellationToken ct)
        {
            var query = _mapper.Map<GetAllBonusesViewModel, GetAllBonusesQuery>(viewModel);
            var result = await _mediator.Send(query, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
