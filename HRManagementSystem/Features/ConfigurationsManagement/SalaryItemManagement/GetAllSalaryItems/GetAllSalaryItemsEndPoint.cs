using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetAllSalaryItems.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetAllSalaryItems
{
    public class GetAllSalaryItemsEndPoint : EndPointBase<GetAllSalaryItemsViewModel, GetAllSalaryItemsQuery, RequestResult<PagedList<ViewSalaryItemDto>>>
    {
        private readonly IMediator _mediator;

        public GetAllSalaryItemsEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpGet("api/SalaryItem/GetAll")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<PagedList<ViewSalaryItemDto>>>>> HandleAsync([FromQuery] GetAllSalaryItemsViewModel viewModel, CancellationToken ct)
        {
            var query = _mapper.Map<GetAllSalaryItemsViewModel, GetAllSalaryItemsQuery>(viewModel);
            var result = await _mediator.Send(query, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
