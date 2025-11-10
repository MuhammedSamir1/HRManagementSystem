using HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.AddRequestType.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.AddRequestType
{
    public class AddRequestTypeEndPoint : BaseEndPoint<AddRequestTypeRequestViewModel, ResponseViewModel<bool>>
    {
        public AddRequestTypeEndPoint(EndPointBaseParameters<AddRequestTypeRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost("add")]
        public async Task<ResponseViewModel<bool>> AddRequestType([FromQuery] AddRequestTypeRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new AddRequestTypeCommand(request.Name, request.Description, request.RequiresAttachments), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(true, "RequestType Added Successfully!");
        }
    }
}

