using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetEndOfServiceById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetEndOfServiceById
{
    public class GetEndOfServiceByIdEndPoint : EndPointBase<GetEndOfServiceByIdViewModel, GetEndOfServiceByIdQuery, RequestResult<ViewEndOfServiceByIdDto>>
    {
        private readonly IMediator _mediator;

        public GetEndOfServiceByIdEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpGet("api/EndOfService/GetById")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<ViewEndOfServiceByIdDto>>>> HandleAsync([FromQuery] GetEndOfServiceByIdViewModel viewModel, CancellationToken ct)
        {
            var query = _mapper.Map<GetEndOfServiceByIdViewModel, GetEndOfServiceByIdQuery>(viewModel);
            var result = await _mediator.Send(query, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
