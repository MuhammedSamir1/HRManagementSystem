using HRManagementSystem.Features.BankManagement.DeleteBank.Commands;

namespace HRManagementSystem.Features.BankManagement.DeleteBank
{
    public class DeleteBankEndPoint : BaseEndPoint<DeleteBankRequestViewModel, ResponseViewModel<bool>>
    {
        public DeleteBankEndPoint(EndPointBaseParameters<DeleteBankRequestViewModel> parameters)
            : base(parameters) { }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> DeleteBank(DeleteBankRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);

            var isDeleted = await _mediator.Send(new DeleteBankCommand(model.Id));
            if (!isDeleted.isSuccess) return ResponseViewModel<bool>.Failure(isDeleted.message, ErrorCode.NotFound);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Bank Deleted Successfully!");
        }
    }
}

