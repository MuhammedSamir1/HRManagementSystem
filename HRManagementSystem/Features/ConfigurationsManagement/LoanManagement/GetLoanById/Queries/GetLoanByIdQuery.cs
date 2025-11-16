using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetLoanById.Queries
{
    public sealed record GetLoanByIdQuery(Guid Id) : IRequest<RequestResult<ViewLoanByIdDto>>;

    public class GetLoanByIdQueryHandler : RequestHandlerBase<GetLoanByIdQuery, RequestResult<ViewLoanByIdDto>, Loan, Guid>
    {
        public GetLoanByIdQueryHandler(RequestHandlerBaseParameters<Loan, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewLoanByIdDto>> Handle(GetLoanByIdQuery request, CancellationToken ct)
        {
            var loan = await _generalRepo.GetByIdAsync(request.Id);

            if (loan == null || loan.IsDeleted)
                return RequestResult<ViewLoanByIdDto>.Failure("Loan not found.", ErrorCode.NotFound);

            var mapped = _mapper.Map<ViewLoanByIdDto>(loan);
            return RequestResult<ViewLoanByIdDto>.Success(mapped);
        }
    }
}

