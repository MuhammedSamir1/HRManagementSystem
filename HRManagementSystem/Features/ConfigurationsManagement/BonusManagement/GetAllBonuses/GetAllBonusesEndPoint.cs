using HRManagementSystem.Common.Extensions;
using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetAllBonuses.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetAllBonuses
{
    [ApiGroup("Configurations Management", "Bonus Management")]
    public class GetAllBonusesEndPoint : BaseEndPoint<GetAllBonusesViewModel, ResponseViewModel<object>>
    {
        public GetAllBonusesEndPoint(EndPointBaseParameters<GetAllBonusesViewModel> parameters) : base(parameters) { }

        [HttpGet]
        public async Task<ResponseViewModel<PagedList<ViewBonusViewModel>>> GetAllBonuses([FromQuery] GetAllBonusesViewModel model, CancellationToken ct)
        {
            var query = _mapper.Map<GetAllBonusesQuery>(model);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<PagedList<ViewBonusViewModel>>.Failure(result.message, result.errorCode);
            }

            var mappedPagedList = result.data!.MapTo<ViewBonusDto, ViewBonusViewModel>(_mapper.ConfigurationProvider);

            return ResponseViewModel<PagedList<ViewBonusViewModel>>.Success(mappedPagedList);
        }
    }
}



