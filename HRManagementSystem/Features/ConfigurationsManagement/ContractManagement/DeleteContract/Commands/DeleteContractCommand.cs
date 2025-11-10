using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.DeleteContract.Commands
{
    public record DeleteContractCommand(int Id) : IRequest<RequestResult<bool>>;

    public class DeleteContractCommandHandler : RequestHandlerBase<DeleteContractCommand, RequestResult<bool>, Contract, int>
    {
        public DeleteContractCommandHandler(RequestHandlerBaseParameters<Contract, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteContractCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted) return RequestResult<bool>.Failure("Contract not found.", ErrorCode.NotFound);

            return RequestResult<bool>.Success(isDeleted, "Contract deleted successfully!");
        }
    }
}

