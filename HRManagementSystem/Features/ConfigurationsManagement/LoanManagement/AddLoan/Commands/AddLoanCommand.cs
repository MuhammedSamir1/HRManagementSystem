using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.AddLoan.Commands
{
    public sealed record AddLoanCommand(
        string Title,
        string? Description,
        decimal Amount,
        decimal RemainingAmount,
        decimal MonthlyInstallment,
        int InstallmentMonths,
        DateTime LoanDate,
        DateTime? StartDeductionDate,
        LoanStatus Status)
        : IRequest<RequestResult<Guid>>;

    public class AddLoanCommandHandler : RequestHandlerBase<AddLoanCommand, RequestResult<Guid>, Loan, Guid>
    {
        public AddLoanCommandHandler(RequestHandlerBaseParameters<Loan, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<Guid>> Handle(AddLoanCommand request, CancellationToken ct)
        {
            var loan = _mapper.Map<Loan>(request);

            var isAdded = await _generalRepo.AddAsync(loan, ct);

            if (!isAdded)
                return RequestResult<Guid>.Failure("Loan wasn't added successfully!", ErrorCode.InternalServerError);

            return RequestResult<Guid>.Success(loan.Id, "Loan added successfully!");
        }
    }
}

