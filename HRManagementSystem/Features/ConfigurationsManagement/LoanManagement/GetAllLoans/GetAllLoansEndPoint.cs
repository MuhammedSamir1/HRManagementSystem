using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetAllLoans.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetAllLoans
{
    public class GetAllLoansEndPoint : EndPointBase<GetAllLoansViewModel, GetAllLoansQuery, RequestResult<PagedList<ViewLoanDto>>>
    {
        private readonly IMediator _mediator;

        public GetAllLoansEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpGet("api/Loan/GetAll")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<PagedList<ViewLoanDto>>>>> HandleAsync([FromQuery] GetAllLoansViewModel viewModel, CancellationToken ct)
        {
            var query = _mapper.Map<GetAllLoansViewModel, GetAllLoansQuery>(viewModel);
            var result = await _mediator.Send(query, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
