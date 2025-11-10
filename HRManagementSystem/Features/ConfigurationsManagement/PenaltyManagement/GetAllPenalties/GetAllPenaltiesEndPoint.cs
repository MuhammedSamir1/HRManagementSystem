using HRManagementSystem.Common.Extensions;
using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetAllPenalties.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetAllPenalties
{
    public class GetAllPenaltiesEndPoint : BaseEndPoint<GetAllPenaltiesViewModel, ResponseViewModel<object>>
    {
        public GetAllPenaltiesEndPoint(EndPointBaseParameters<GetAllPenaltiesViewModel> parameters) : base(parameters) { }

        [HttpGet]
        public async Task<ResponseViewModel<PagedList<ViewPenaltyViewModel>>> GetAllPenalties([FromQuery] GetAllPenaltiesViewModel model, CancellationToken ct)
        {
            var query = _mapper.Map<GetAllPenaltiesQuery>(model);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<PagedList<ViewPenaltyViewModel>>.Failure(result.message, result.errorCode);
            }

            var mappedPagedList = result.data!.MapTo<ViewPenaltyDto, ViewPenaltyViewModel>(_mapper.ConfigurationProvider);

            return ResponseViewModel<PagedList<ViewPenaltyViewModel>>.Success(mappedPagedList);
        }
    }
}
