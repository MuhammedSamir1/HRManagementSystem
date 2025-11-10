using HRManagementSystem.Common.Extensions;
using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetAllSalaryItems.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetAllSalaryItems
{
    public class GetAllSalaryItemsEndPoint : BaseEndPoint<GetAllSalaryItemsViewModel, ResponseViewModel<object>>
    {
        public GetAllSalaryItemsEndPoint(EndPointBaseParameters<GetAllSalaryItemsViewModel> parameters) : base(parameters) { }

        [HttpGet]
        public async Task<ResponseViewModel<PagedList<ViewSalaryItemViewModel>>> GetAllSalaryItems([FromQuery] GetAllSalaryItemsViewModel model, CancellationToken ct)
        {
            var query = _mapper.Map<GetAllSalaryItemsQuery>(model);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<PagedList<ViewSalaryItemViewModel>>.Failure(result.message, result.errorCode);
            }

            var mappedPagedList = result.data!.MapTo<ViewSalaryItemDto, ViewSalaryItemViewModel>(_mapper.ConfigurationProvider);

            return ResponseViewModel<PagedList<ViewSalaryItemViewModel>>.Success(mappedPagedList);
        }
    }
}
