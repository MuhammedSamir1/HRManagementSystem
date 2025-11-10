using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetPenaltyById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetPenaltyById
{
    public class GetPenaltyByIdEndPoint : EndPointBase<GetPenaltyByIdViewModel, GetPenaltyByIdQuery, RequestResult<ViewPenaltyByIdDto>>
    {
        private readonly IMediator _mediator;

        public GetPenaltyByIdEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpGet("api/Penalty/GetById")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<ViewPenaltyByIdDto>>>> HandleAsync([FromQuery] GetPenaltyByIdViewModel viewModel, CancellationToken ct)
        {
            var query = _mapper.Map<GetPenaltyByIdViewModel, GetPenaltyByIdQuery>(viewModel);
            var result = await _mediator.Send(query, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
