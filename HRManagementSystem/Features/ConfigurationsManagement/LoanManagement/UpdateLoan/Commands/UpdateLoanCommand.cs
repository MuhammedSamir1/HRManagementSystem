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
        : IRequest<RequestResult<string>>;

    public class UpdateLoanCommandHandler : RequestHandlerBase<UpdateLoanCommand, RequestResult<string>, Loan, int>
    {
        public UpdateLoanCommandHandler(RequestHandlerBaseParameters<Loan, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<string>> Handle(UpdateLoanCommand request, CancellationToken ct)
        {
            var loan = await _generalRepo.GetByIdAsync(request.Id, ct);

            if (loan == null)
                return RequestResult<string>.Failure("Loan not found.", ErrorCode.NotFound);

            _mapper.Map(request, loan);

            var isUpdated = await _generalRepo.UpdateAsync(loan, ct);

            if (!isUpdated)
                return RequestResult<string>.Failure("Loan wasn't updated successfully!", ErrorCode.InternalServerError);

            return RequestResult<string>.Success("Loan updated successfully!");
        }
    }
}
