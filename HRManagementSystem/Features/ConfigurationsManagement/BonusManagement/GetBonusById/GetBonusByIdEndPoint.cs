using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetBonusById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetBonusById
{
    public class GetBonusByIdEndPoint : BaseEndPoint<GetBonusByIdViewModel, ResponseViewModel<ViewBonusByIdViewModel>>
    {
        public GetBonusByIdEndPoint(EndPointBaseParameters<GetBonusByIdViewModel> parameters) : base(parameters) { }

        [HttpGet("{id:int}")]
        public async Task<ResponseViewModel<ViewBonusByIdViewModel>> GetBonusById(int id, CancellationToken ct)
        {
            var query = new GetBonusByIdQuery(id);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<ViewBonusByIdViewModel>.Failure(result.message, result.errorCode);
            }

            var mapped = _mapper.Map<ViewBonusByIdViewModel>(result.data);

            return ResponseViewModel<ViewBonusByIdViewModel>.Success(mapped);
        }
    }
}
