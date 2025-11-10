using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetSalaryItemById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetSalaryItemById
{
    public class GetSalaryItemByIdEndPoint : EndPointBase<GetSalaryItemByIdViewModel, GetSalaryItemByIdQuery, RequestResult<ViewSalaryItemByIdDto>>
    {
        private readonly IMediator _mediator;

        public GetSalaryItemByIdEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpGet("api/SalaryItem/GetById")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<ViewSalaryItemByIdDto>>>> HandleAsync([FromQuery] GetSalaryItemByIdViewModel viewModel, CancellationToken ct)
        {
            var query = _mapper.Map<GetSalaryItemByIdViewModel, GetSalaryItemByIdQuery>(viewModel);
            var result = await _mediator.Send(query, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
