using HRManagementSystem.Features.StateManagement.DeleteState.Command;

namespace HRManagementSystem.Features.StateManagement.DeleteState
{
    [ApiGroup("State Management")]
    public class DeleteStateEndPoint : BaseEndPoint<DeleteStateViewModel,
    ResponseViewModel<DeleteStateResponseViewModel>>
    {
        public DeleteStateEndPoint(EndPointBaseParameters<DeleteStateViewModel> parameters)
            : base(parameters) { }

        [HttpDelete()]
        public async Task<ResponseViewModel<DeleteStateResponseViewModel>> Delete([FromBody] DeleteStateViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<DeleteStateResponseViewModel>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new DeleteStateCommand(model.Id));

            if (!result.isSuccess)
            {
                return ResponseViewModel<DeleteStateResponseViewModel>.Failure(result.message, result.errorCode);
            }

            var response = new DeleteStateResponseViewModel
            {
                Success = true,
                Message = "State deleted successfully"
            };

            return ResponseViewModel<DeleteStateResponseViewModel>.Success(response);
        }
    }
}

