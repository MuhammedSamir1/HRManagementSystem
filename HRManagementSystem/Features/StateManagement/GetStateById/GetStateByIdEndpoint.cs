using HRManagementSystem.Features.Common.AddressManagement.StateCommon.ViewModels;
using HRManagementSystem.Features.StateManagement.GetStateById.Queries;

namespace HRManagementSystem.Features.StateManagement.GetStateById
{
    public class GetStateByIdEndPoint : BaseEndPoint<GetStateByIdViewModel,
    ResponseViewModel<ViewStateViewModel>>
    {
        public GetStateByIdEndPoint(EndPointBaseParameters<GetStateByIdViewModel> parameters)
            : base(parameters) { }

        [HttpGet()]
        public async Task<ResponseViewModel<ViewStateViewModel>> GetById([FromQuery] GetStateByIdViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewStateViewModel>.Failure(validationResult.errorCode);
            }

            var state = await _mediator.Send(new GetStateByIdQuery(model.Id));

            if (!state.isSuccess)
                return ResponseViewModel<ViewStateViewModel>.Failure(state.message, ErrorCode.StateNotFound);

            var vm = _mapper.Map<ViewStateViewModel>(state.data);
            return ResponseViewModel<ViewStateViewModel>.Success(vm);
        }
    }
}
