namespace HRManagementSystem.Features.BankManagement.DeleteBank.Commands
{
    public record DeleteBankCommand(int Id) : IRequest<RequestResult<bool>>;

    public class DeleteBankCommandHandler : RequestHandlerBase<DeleteBankCommand, RequestResult<bool>, Bank, int>
    {
        public DeleteBankCommandHandler(RequestHandlerBaseParameters<Bank, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteBankCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted) return RequestResult<bool>.Failure("Bank not found.", ErrorCode.NotFound);

            return RequestResult<bool>.Success(isDeleted, "Bank deleted successfully!");
        }
    }
}

