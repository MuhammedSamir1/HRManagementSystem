using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetLoanById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetLoanById
{
    public class GetLoanByIdEndPoint : EndPointBase<GetLoanByIdViewModel, GetLoanByIdQuery, RequestResult<ViewLoanByIdDto>>
    {
        private readonly IMediator _mediator;

        public GetLoanByIdEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpGet("api/Loan/GetById")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<ViewLoanByIdDto>>>> HandleAsync([FromQuery] GetLoanByIdViewModel viewModel, CancellationToken ct)
        {
            var query = _mapper.Map<GetLoanByIdViewModel, GetLoanByIdQuery>(viewModel);
            var result = await _mediator.Send(query, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
