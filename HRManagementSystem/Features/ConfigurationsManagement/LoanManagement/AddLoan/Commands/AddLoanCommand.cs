using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;

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
        : IRequest<RequestResult<CreatedIdDto>>;

    public class AddLoanCommandHandler : RequestHandlerBase<AddLoanCommand, RequestResult<CreatedIdDto>, Loan, int>
    {
        public AddLoanCommandHandler(RequestHandlerBaseParameters<Loan, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddLoanCommand request, CancellationToken ct)
        {
            var loan = _mapper.Map<AddLoanCommand, Loan>(request);

            var isAdded = await _generalRepo.AddAsync(loan, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Loan wasn't added successfully!", ErrorCode.InternalServerError);

            var mapped = _mapper.Map<CreatedIdDto>(loan);
            return RequestResult<CreatedIdDto>.Success(mapped, "Loan added successfully!");
        }
    }
}

