using HRManagementSystem.Features.ContractManagement.DeleteContract.Commands;

namespace HRManagementSystem.Features.ContractManagement.DeleteContract
{
    public class DeleteContractEndPoint : BaseEndPoint<DeleteContractRequestViewModel, ResponseViewModel<bool>>
    {
        public DeleteContractEndPoint(EndPointBaseParameters<DeleteContractRequestViewModel> parameters)
            : base(parameters) { }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> DeleteContract(DeleteContractRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);

            var isDeleted = await _mediator.Send(new DeleteContractCommand(model.Id));
            if (!isDeleted.isSuccess) return ResponseViewModel<bool>.Failure(isDeleted.message, ErrorCode.NotFound);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Contract Deleted Successfully!");
        }
    }
}

