using HRManagementSystem.Features.StateManagement.DeleteState.Command;

namespace HRManagementSystem.Features.StateManagement.DeleteState
{
    public class DeleteStateEndPoint : BaseEndPoint<DeleteStateViewModel,
    ResponseViewModel<DeleteStateResponseViewModel>>
    {
        public DeleteStateEndPoint(EndPointBaseParameters<DeleteStateViewModel> parameters)
            : base(parameters) { }

        [HttpDelete("{id}")]
        public async Task<ResponseViewModel<DeleteStateResponseViewModel>> Delete([FromRoute] DeleteStateViewModel model)
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
