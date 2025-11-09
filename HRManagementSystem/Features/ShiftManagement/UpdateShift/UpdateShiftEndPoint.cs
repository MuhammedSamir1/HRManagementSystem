using HRManagementSystem.Features.ShiftManagement.UpdateShift.Commands;

namespace HRManagementSystem.Features.ShiftManagement.UpdateShift
{
    public class UpdateShiftEndPoint : BaseEndPoint<UpdateShiftViewModel, RequestResult<bool>>
    {
        public UpdateShiftEndPoint(EndPointBaseParameters<UpdateShiftViewModel> parameters) : base(parameters) { }

        [HttpPut("update")]
        public async Task<ResponseViewModel<bool>> UpdateShift([FromQuery] UpdateShiftViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new UpdateShiftCommand(model.Id, model.Name, model.StartTime,
                 model.EndTime), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            return ResponseViewModel<bool>.Success(result.isSuccess, "Shift Updated Successfully!");
        }
    }
}

