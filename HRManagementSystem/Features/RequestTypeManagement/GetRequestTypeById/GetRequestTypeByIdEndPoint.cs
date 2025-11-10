using HRManagementSystem.Features.RequestTypeManagement.GetRequestTypeById.Queries;

namespace HRManagementSystem.Features.RequestTypeManagement.GetRequestTypeById
{
    public class GetRequestTypeByIdEndPoint : BaseEndPoint<GetRequestTypeByIdRequestViewModel, ResponseViewModel<GetRequestTypeByIdResponseViewModel>>
    {
        public GetRequestTypeByIdEndPoint(EndPointBaseParameters<GetRequestTypeByIdRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet("GetById")]
        public async Task<ResponseViewModel<GetRequestTypeByIdResponseViewModel>> GetRequestTypeById([FromQuery] GetRequestTypeByIdRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<GetRequestTypeByIdResponseViewModel>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new GetRequestTypeByIdQuery(request.Id), ct);

            if (!result.isSuccess || result.data == null)
                return ResponseViewModel<GetRequestTypeByIdResponseViewModel>.Failure(ErrorCode.NotFound);

            var responseViewModel = _mapper.Map<GetRequestTypeByIdResponseViewModel>(result.data);

            return ResponseViewModel<GetRequestTypeByIdResponseViewModel>.Success(responseViewModel, "RequestType returned successfully!");
        }
    }
}

