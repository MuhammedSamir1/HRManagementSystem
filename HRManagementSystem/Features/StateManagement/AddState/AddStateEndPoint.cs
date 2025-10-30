using HRManagementSystem.Features.Common.AddressManagement.StateCommon.ViewModels;
using HRManagementSystem.Features.StateManagement.AddState.Command;

namespace HRManagementSystem.Features.StateManagement.AddState
{
    public class AddStateEndPoint : BaseEndPoint<AddStateViewModel,
     ResponseViewModel<ViewStateViewModel>>
    {
        public AddStateEndPoint(EndPointBaseParameters<AddStateViewModel> parameters)
            : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<ViewStateViewModel>> Add([FromBody] AddStateViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewStateViewModel>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new AddStateCommand(model.Code, model.Name, model.CountryId));

            if (!result.isSuccess)
            {
                return ResponseViewModel<ViewStateViewModel>.Failure(result.message, result.errorCode);
            }

            var vm = _mapper.Map<ViewStateViewModel>(result.data);
            return ResponseViewModel<ViewStateViewModel>.Success(vm, "State created successfully");
        }
    }
}
