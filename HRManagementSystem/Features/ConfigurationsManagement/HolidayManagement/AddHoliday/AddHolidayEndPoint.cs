using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.AddHoliday.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.AddHoliday
{
    [ApiGroup("Configurations Management", "Holiday Management")]
    public class AddHolidayEndPoint : BaseEndPoint<AddHolidayRequestViewModel, ResponseViewModel<bool>>
    {
        public AddHolidayEndPoint(EndPointBaseParameters<AddHolidayRequestViewModel> parameters) : base(parameters) { }

        [HttpPost("add")]
        public async Task<ResponseViewModel<bool>> AddHoliday([FromBody] AddHolidayRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var command = _mapper.Map<AddHolidayCommand>(model);
            var result = await _mediator.Send(command, ct);

            //   (???????  ?? ?????)
            if (!result.isSuccess)
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);

            return ResponseViewModel<bool>.Success(true, "Holiday added successfully!");
        }
    }
}



