using HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.AddShift.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.AddShift
{
    public class AddShiftEndPoint : BaseEndPoint<AddShiftViewModel, ResponseViewModel<bool>>
    {
        public AddShiftEndPoint(EndPointBaseParameters<AddShiftViewModel> parameters)
            : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> AddShift([FromQuery] AddShiftViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new AddShiftCommand(model.Name, model.StartTime, model.EndTime), ct);


            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Shift Added Successfully!");
        }
    }
}

