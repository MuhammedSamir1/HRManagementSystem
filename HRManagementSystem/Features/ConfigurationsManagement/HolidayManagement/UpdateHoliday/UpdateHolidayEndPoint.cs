using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.UpdateHoliday.Command;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.UpdateHoliday
{
    public class UpdateHolidayEndPoint : BaseEndPoint<UpdateHolidayRequestViewModel, ResponseViewModel<bool>>
    {
        public UpdateHolidayEndPoint(EndPointBaseParameters<UpdateHolidayRequestViewModel> parameters) : base(parameters) { }

        [HttpPut("update")]
        public async Task<ResponseViewModel<bool>> UpdateHoliday([FromBody] UpdateHolidayRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var command = _mapper.Map<UpdateHolidayCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);

            return ResponseViewModel<bool>.Success(true, "Holiday updated successfully!");
        }
    }
}
