using HRManagementSystem.Features.RequestTypeManagement.UpdateRequestType.Commands;

namespace HRManagementSystem.Features.RequestTypeManagement.UpdateRequestType
{
    public class UpdateRequestTypeEndPoint : BaseEndPoint<UpdateRequestTypeRequestViewModel, ResponseViewModel<bool>>
    {
        public UpdateRequestTypeEndPoint(EndPointBaseParameters<UpdateRequestTypeRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPut("update")]
        public async Task<ResponseViewModel<bool>> UpdateRequestType([FromQuery] UpdateRequestTypeRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new UpdateRequestTypeCommand(request.Id, request.Name, request.Description, request.RequiresAttachments), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            return ResponseViewModel<bool>.Success(true, "RequestType Updated Successfully!");
        }
    }
}

