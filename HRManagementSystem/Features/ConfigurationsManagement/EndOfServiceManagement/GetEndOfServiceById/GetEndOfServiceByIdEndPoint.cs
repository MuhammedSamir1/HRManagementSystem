using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetEndOfServiceById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetEndOfServiceById
{
    public class GetEndOfServiceByIdEndPoint : BaseEndPoint<GetEndOfServiceByIdViewModel, ResponseViewModel<ViewEndOfServiceByIdViewModel>>
    {
        public GetEndOfServiceByIdEndPoint(EndPointBaseParameters<GetEndOfServiceByIdViewModel> parameters) : base(parameters) { }

        [HttpGet("{id:int}")]
        public async Task<ResponseViewModel<ViewEndOfServiceByIdViewModel>> GetEndOfServiceById(Guid id, CancellationToken ct)
        {
            var query = new GetEndOfServiceByIdQuery(id);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<ViewEndOfServiceByIdViewModel>.Failure(result.message, result.errorCode);
            }

            var mapped = _mapper.Map<ViewEndOfServiceByIdViewModel>(result.data);

            return ResponseViewModel<ViewEndOfServiceByIdViewModel>.Success(mapped);
        }
    }
}

