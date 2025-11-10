using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.UpdateLoan.Commands
{
    public sealed record UpdateLoanCommand(
        int Id,
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
        : IRequest<RequestResult<bool>>;

    public class UpdateLoanCommandHandler : RequestHandlerBase<UpdateLoanCommand, RequestResult<bool>, Loan, int>
    {
        public UpdateLoanCommandHandler(RequestHandlerBaseParameters<Loan, int> parameters)
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
            loan.EmployeeId = request.EmployeeId;

            await _generalRepo.UpdateAsync(loan, ct);

            return RequestResult<bool>.Success(true, "Loan updated successfully!");
        }
    }
}
