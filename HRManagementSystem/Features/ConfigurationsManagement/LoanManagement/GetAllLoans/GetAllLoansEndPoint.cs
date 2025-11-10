using HRManagementSystem.Common.Extensions;
using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetAllLoans.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetAllLoans
{
    public class GetAllLoansEndPoint : BaseEndPoint<GetAllLoansViewModel, ResponseViewModel<object>>
    {
        public GetAllLoansEndPoint(EndPointBaseParameters<GetAllLoansViewModel> parameters) : base(parameters) { }

        [HttpGet]
        public async Task<ResponseViewModel<PagedList<ViewLoanViewModel>>> GetAllLoans([FromQuery] GetAllLoansViewModel model, CancellationToken ct)
        {
            var query = _mapper.Map<GetAllLoansQuery>(model);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<PagedList<ViewLoanViewModel>>.Failure(result.message, result.errorCode);
            }

            var mappedPagedList = result.data!.MapTo<ViewLoanDto, ViewLoanViewModel>(_mapper.ConfigurationProvider);

            return ResponseViewModel<PagedList<ViewLoanViewModel>>.Success(mappedPagedList);
        }
    }
}
