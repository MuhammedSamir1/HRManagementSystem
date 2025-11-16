using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.BankManagement.DeleteBank.Commands
{
    public record DeleteBankCommand(Guid Id) : IRequest<RequestResult<bool>>;

    public class DeleteBankCommandHandler : RequestHandlerBase<DeleteBankCommand, RequestResult<bool>, Bank, Guid>
    {
        public DeleteBankCommandHandler(RequestHandlerBaseParameters<Bank, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteBankCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted) return RequestResult<bool>.Failure("Bank not found.", ErrorCode.NotFound);

            return RequestResult<bool>.Success(isDeleted, "Bank deleted successfully!");
        }
    }
}


