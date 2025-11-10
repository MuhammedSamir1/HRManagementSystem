using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetAllPenalties.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetAllPenalties
{
    public class GetAllPenaltiesEndPoint : EndPointBase<GetAllPenaltiesViewModel, GetAllPenaltiesQuery, RequestResult<PagedList<ViewPenaltyDto>>>
    {
        private readonly IMediator _mediator;

        public GetAllPenaltiesEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpGet("api/Penalty/GetAll")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<PagedList<ViewPenaltyDto>>>>> HandleAsync([FromQuery] GetAllPenaltiesViewModel viewModel, CancellationToken ct)
        {
            var query = _mapper.Map<GetAllPenaltiesViewModel, GetAllPenaltiesQuery>(viewModel);
            var result = await _mediator.Send(query, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
