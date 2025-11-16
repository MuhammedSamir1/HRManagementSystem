using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.UpdateLoan.Commands
{
    public sealed record UpdateLoanCommand(
        Guid Id,
        string Title,
        string? Description,
        decimal Amount,
        decimal RemainingAmount,
        decimal MonthlyInstallment,
        int InstallmentMonths,
        DateTime LoanDate,
        DateTime? StartDeductionDate,
        LoanStatus Status)
        : IRequest<RequestResult<bool>>;

    public class UpdateLoanCommandHandler : RequestHandlerBase<UpdateLoanCommand, RequestResult<bool>, Loan, Guid>
    {
        public UpdateLoanCommandHandler(RequestHandlerBaseParameters<Loan, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(UpdateLoanCommand request, CancellationToken ct)
        {
            var loan = await _generalRepo.GetByIdWithTracking(request.Id);

            if (loan == null || loan.IsDeleted)
                return RequestResult<bool>.Failure("Loan not found.", ErrorCode.NotFound);

            loan.Title = request.Title;
            loan.Description = request.Description;
            loan.Amount = request.Amount;
            loan.RemainingAmount = request.RemainingAmount;
            loan.MonthlyInstallment = request.MonthlyInstallment;
            loan.InstallmentMonths = request.InstallmentMonths;
            loan.LoanDate = request.LoanDate;
            loan.StartDeductionDate = request.StartDeductionDate;
            loan.Status = request.Status;

            await _generalRepo.UpdateAsync(loan, ct);

            return RequestResult<bool>.Success(true, "Loan updated successfully!");
        }
    }
}

