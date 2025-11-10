using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetAllEndOfServices.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetAllEndOfServices
{
    public class GetAllEndOfServicesEndPoint : EndPointBase<GetAllEndOfServicesViewModel, GetAllEndOfServicesQuery, RequestResult<PagedList<ViewEndOfServiceDto>>>
    {
        private readonly IMediator _mediator;

        public GetAllEndOfServicesEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpGet("api/EndOfService/GetAll")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<PagedList<ViewEndOfServiceDto>>>>> HandleAsync([FromQuery] GetAllEndOfServicesViewModel viewModel, CancellationToken ct)
        {
            var query = _mapper.Map<GetAllEndOfServicesViewModel, GetAllEndOfServicesQuery>(viewModel);
            var result = await _mediator.Send(query, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
