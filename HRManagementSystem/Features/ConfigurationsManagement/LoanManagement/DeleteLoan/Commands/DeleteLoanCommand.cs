using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.DeleteLoan.Commands
{
    public sealed record DeleteLoanCommand(int Id) : IRequest<RequestResult<string>>;

    public class DeleteLoanCommandHandler : RequestHandlerBase<DeleteLoanCommand, RequestResult<string>, Loan, int>
    {
        public DeleteLoanCommandHandler(RequestHandlerBaseParameters<Loan, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<string>> Handle(DeleteLoanCommand request, CancellationToken ct)
        {
            var loan = await _generalRepo.GetByIdAsync(request.Id, ct);

            if (loan == null)
                return RequestResult<string>.Failure("Loan not found.", ErrorCode.NotFound);

            var isDeleted = await _generalRepo.DeleteAsync(loan, ct);

            if (!isDeleted)
                return RequestResult<string>.Failure("Loan wasn't deleted successfully!", ErrorCode.InternalServerError);

            return RequestResult<string>.Success("Loan deleted successfully!");
        }
    }
}
