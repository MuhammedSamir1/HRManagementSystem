using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Common.Views;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetAllLoans.Queries
{
    public sealed record GetAllLoansQuery() : IRequest<RequestResult<PagedList<ViewLoanDto>>>;

    public class GetAllLoansQueryHandler : RequestHandlerBase<GetAllLoansQuery, RequestResult<PagedList<ViewLoanDto>>, Loan, int>
    {
        public GetAllLoansQueryHandler(RequestHandlerBaseParameters<Loan, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<PagedList<ViewLoanDto>>> Handle(GetAllLoansQuery request, CancellationToken ct)
        {
            var query = _generalRepo.Get(x => !x.IsDeleted, ct);

            var pagedList = await PagedList<ViewLoanDto>.CreateAsync(
                query,
                1,
                100,
                _mapper,
                ct
            );

            return RequestResult<PagedList<ViewLoanDto>>.Success(pagedList);
        }
    }
}
