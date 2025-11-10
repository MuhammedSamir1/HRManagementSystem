using HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetShiftById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetShiftById
{
    public class GetShiftByIdEndPoint : BaseEndPoint<GetShiftByIdViewModel,
       ResponseViewModel<ViewShiftByIdViewModel>>
    {
        public GetShiftByIdEndPoint(EndPointBaseParameters<GetShiftByIdViewModel> parameters)
            : base(parameters) { }

        [HttpGet("id")]
        public async Task<ResponseViewModel<ViewShiftByIdViewModel>> GetById([FromQuery] GetShiftByIdViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewShiftByIdViewModel>.Failure(validationResult.errorCode);
            }

            var shift = await _mediator.Send(new GetShiftByIdQuery(model.Id));

            if (shift is null) return ResponseViewModel<ViewShiftByIdViewModel>.Failure(shift.message,
                ErrorCode.ShiftNotFound);

            var vm = _mapper.Map<ViewShiftByIdViewModel>(shift.data);
            return ResponseViewModel<ViewShiftByIdViewModel>.Success(vm);
        }
    }
}

