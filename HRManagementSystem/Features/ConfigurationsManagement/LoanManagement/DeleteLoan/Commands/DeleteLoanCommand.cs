using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.DeleteLoan.Commands
{
    public sealed record DeleteLoanCommand(Guid Id) : IRequest<RequestResult<bool>>;

    public class DeleteLoanCommandHandler : RequestHandlerBase<DeleteLoanCommand, RequestResult<bool>, Loan, Guid>
    {
        public DeleteLoanCommandHandler(RequestHandlerBaseParameters<Loan, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteLoanCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted)
                return RequestResult<bool>.Failure("Loan not found or wasn't deleted successfully!", ErrorCode.NotFound);

            return RequestResult<bool>.Success(true, "Loan deleted successfully!");
        }
    }
}

