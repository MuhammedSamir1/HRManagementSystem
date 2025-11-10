using HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.DeleteShift.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.DeleteShift
{
    public class DeleteShiftEndPoint : BaseEndPoint<DeleteShiftViewModel, ResponseViewModel<bool>>
    {
        public DeleteShiftEndPoint(EndPointBaseParameters<DeleteShiftViewModel> parameters)
            : base(parameters) { }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> DeleteShift(DeleteShiftViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);

            var isDeleted = await _mediator.Send(new DeleteShiftCommand(model.Id));
            if (!isDeleted.isSuccess) return ResponseViewModel<bool>.Failure(isDeleted.message,
                ErrorCode.ShiftWasNotDeleted);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Shift Deleted Successfully!");
        }
    }
}

