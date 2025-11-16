using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.DeleteContract.Commands
{
    public record DeleteContractCommand(Guid Id) : IRequest<RequestResult<bool>>;

    public class DeleteContractCommandHandler : RequestHandlerBase<DeleteContractCommand, RequestResult<bool>, Contract, Guid>
    {
        public DeleteContractCommandHandler(RequestHandlerBaseParameters<Contract, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteContractCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted) return RequestResult<bool>.Failure("Contract not found.", ErrorCode.NotFound);

            return RequestResult<bool>.Success(isDeleted, "Contract deleted successfully!");
        }
    }
}


