using HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.GetAllRequestTypes.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.GetAllRequestTypes
{
    [ApiGroup("Configurations Management", "Request Type Management")]
    public class GetAllRequestTypesEndPoint : BaseEndPoint<GetAllRequestTypesRequestViewModel, ResponseViewModel<IEnumerable<GetAllRequestTypesResponseViewModel>>>
    {
        public GetAllRequestTypesEndPoint(EndPointBaseParameters<GetAllRequestTypesRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet("GetAll")]
        public async Task<ResponseViewModel<IEnumerable<GetAllRequestTypesResponseViewModel>>> GetAllRequestTypes([FromQuery] GetAllRequestTypesRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<IEnumerable<GetAllRequestTypesResponseViewModel>>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new GetAllRequestTypesQuery(), ct);

            if (!result.isSuccess || result.data == null || !result.data.Any())
                return ResponseViewModel<IEnumerable<GetAllRequestTypesResponseViewModel>>.Failure(ErrorCode.NotFound);

            var responseViewModel = _mapper.Map<IEnumerable<GetAllRequestTypesResponseViewModel>>(result.data);

            return ResponseViewModel<IEnumerable<GetAllRequestTypesResponseViewModel>>.Success(responseViewModel, "RequestTypes returned successfully!");
        }
    }
}




