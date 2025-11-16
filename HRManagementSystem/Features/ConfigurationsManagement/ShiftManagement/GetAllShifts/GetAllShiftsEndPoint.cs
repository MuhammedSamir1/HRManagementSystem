using HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetAllShifts.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetAllShifts
{
    [ApiGroup("Configurations Management", "Shift Management")]
    public class GetAllShiftsEndPoint : BaseEndPoint<GetAllShiftsViewModel,
       ResponseViewModel<ViewShiftViewModel>>
    {
        public GetAllShiftsEndPoint(EndPointBaseParameters<GetAllShiftsViewModel> parameters)
            : base(parameters) { }

        [HttpGet("id")]
        public async Task<ResponseViewModel<List<ViewShiftViewModel>>> GetById([FromQuery] GetAllShiftsViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<List<ViewShiftViewModel>>.Failure(validationResult.errorCode);
            }

            var shift = await _mediator.Send(new GetAllShiftsQuery());

            if (shift is null) return ResponseViewModel<List<ViewShiftViewModel>>.Failure(shift.message,
                ErrorCode.ShiftNotFound);

            var vm = _mapper.Map<List<ViewShiftViewModel>>(shift.data);
            return ResponseViewModel<List<ViewShiftViewModel>>.Success(vm);
        }
    }
}




