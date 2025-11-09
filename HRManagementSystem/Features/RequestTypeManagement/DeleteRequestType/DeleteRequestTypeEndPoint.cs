using HRManagementSystem.Features.RequestTypeManagement.DeleteRequestType.Commands;

namespace HRManagementSystem.Features.RequestTypeManagement.DeleteRequestType
{
    public class DeleteRequestTypeEndPoint : BaseEndPoint<DeleteRequestTypeRequestViewModel, ResponseViewModel<bool>>
    {
        public DeleteRequestTypeEndPoint(EndPointBaseParameters<DeleteRequestTypeRequestViewModel> parameters)
            : base(parameters) { }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> DeleteRequestType(DeleteRequestTypeRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);

            var isDeleted = await _mediator.Send(new DeleteRequestTypeCommand(model.Id));
            if (!isDeleted.isSuccess) return ResponseViewModel<bool>.Failure(isDeleted.message, ErrorCode.NotFound);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "RequestType Deleted Successfully!");
        }
    }
}

