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
        LoanStatus Status,
        int? EmployeeId)
        : IRequest<RequestResult<int>>;

    public class AddLoanCommandHandler : RequestHandlerBase<AddLoanCommand, RequestResult<int>, Loan, int>
    {
        public AddLoanCommandHandler(RequestHandlerBaseParameters<Loan, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<int>> Handle(AddLoanCommand request, CancellationToken ct)
        {
            var loan = _mapper.Map<Loan>(request);

            var isAdded = await _generalRepo.AddAsync(loan, ct);

            if (!isAdded) 
                return RequestResult<int>.Failure("Loan wasn't added successfully!", ErrorCode.InternalServerError);

            return RequestResult<int>.Success(loan.Id, "Loan added successfully!");
        }
    }
}
