using HRManagementSystem.Features.Common.AddressManagement.StateCommon.ViewModels;
using HRManagementSystem.Features.StateManagement.UpdateState.Command;

namespace HRManagementSystem.Features.StateManagement.UpdateState
{
    public class UpdateStateEndPoint : BaseEndPoint<UpdateStateViewModel,
     ResponseViewModel<ViewStateViewModel>>
    {
        public UpdateStateEndPoint(EndPointBaseParameters<UpdateStateViewModel> parameters)
            : base(parameters) { }

        [HttpPut("{id}")]
        public async Task<ResponseViewModel<ViewStateViewModel>> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateStateViewModel model)
        {
            // Ensure ID from route matches ID from body
            if (id != model.Id)
            {
                return ResponseViewModel<ViewStateViewModel>.Failure(ErrorCode.InvalidRequest);
            }

            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewStateViewModel>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new UpdateStateCommand(model.Id, model.Code, model.Name, model.CountryId));

            if (!result.isSuccess)
            {
                return ResponseViewModel<ViewStateViewModel>.Failure(result.message, result.errorCode);
            }

            var vm = _mapper.Map<ViewStateViewModel>(result.data);
            return ResponseViewModel<ViewStateViewModel>.Success(vm, "State updated successfully");
        }
    }
}
