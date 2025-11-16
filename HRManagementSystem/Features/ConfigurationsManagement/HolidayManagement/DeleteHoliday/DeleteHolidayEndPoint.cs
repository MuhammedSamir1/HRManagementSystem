using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.DeleteHoliday.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.DeleteHoliday
{
    public class DeleteHolidayEndPoint : BaseEndPoint<DeleteHolidayViewModel, ResponseViewModel<bool>>
    {
        public DeleteHolidayEndPoint(EndPointBaseParameters<DeleteHolidayViewModel> parameters) : base(parameters) { }

        [HttpDelete("delete/{id:int}")]
        public async Task<ResponseViewModel<bool>> DeleteHoliday([FromRoute] Guid id, CancellationToken ct)
        {
            var model = new DeleteHolidayViewModel(id);
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var command = _mapper.Map<DeleteHolidayCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);

            return ResponseViewModel<bool>.Success(true, "Holiday Deleted Successfully!");
        }
    }
}

