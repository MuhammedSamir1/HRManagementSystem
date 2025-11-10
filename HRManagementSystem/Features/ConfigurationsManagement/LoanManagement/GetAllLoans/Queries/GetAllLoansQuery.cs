using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetAllLoans.Queries
{
    public sealed record GetAllLoansQuery() : IRequest<RequestResult<PagedList<ViewLoanDto>>>;

    public class GetAllLoansQueryHandler : RequestHandlerBase<GetAllLoansQuery, RequestResult<PagedList<ViewLoanDto>>, Loan, int>
    {
        public GetAllLoansQueryHandler(RequestHandlerBaseParameters<Loan, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<PagedList<ViewLoanDto>>> Handle(GetAllLoansQuery request, CancellationToken ct)
        {
            var loans = await _generalRepo.GetAllAsync(ct);
            var mapped = _mapper.Map<PagedList<ViewLoanDto>>(loans);
            return RequestResult<PagedList<ViewLoanDto>>.Success(mapped);
        }
    }
}
