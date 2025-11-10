using HRManagementSystem.Common.Extensions;
using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetAllEndOfServices.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetAllEndOfServices
{
    public class GetAllEndOfServicesEndPoint : BaseEndPoint<GetAllEndOfServicesViewModel, ResponseViewModel<object>>
    {
        public GetAllEndOfServicesEndPoint(EndPointBaseParameters<GetAllEndOfServicesViewModel> parameters) : base(parameters) { }

        [HttpGet]
        public async Task<ResponseViewModel<PagedList<ViewEndOfServiceViewModel>>> GetAllEndOfServices([FromQuery] GetAllEndOfServicesViewModel model, CancellationToken ct)
        {
            var query = _mapper.Map<GetAllEndOfServicesQuery>(model);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<PagedList<ViewEndOfServiceViewModel>>.Failure(result.message, result.errorCode);
            }

            var mappedPagedList = result.data!.MapTo<ViewEndOfServiceDto, ViewEndOfServiceViewModel>(_mapper.ConfigurationProvider);

            return ResponseViewModel<PagedList<ViewEndOfServiceViewModel>>.Success(mappedPagedList);
        }
    }
}
