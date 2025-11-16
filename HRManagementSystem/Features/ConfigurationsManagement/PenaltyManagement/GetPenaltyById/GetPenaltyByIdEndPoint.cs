using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetPenaltyById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetPenaltyById
{
    [ApiGroup("Configurations Management", "Penalty Management")]
    public class GetPenaltyByIdEndPoint : BaseEndPoint<GetPenaltyByIdViewModel, ResponseViewModel<ViewPenaltyByIdViewModel>>
    {
        public GetPenaltyByIdEndPoint(EndPointBaseParameters<GetPenaltyByIdViewModel> parameters) : base(parameters) { }

        [HttpGet("{id:int}")]
        public async Task<ResponseViewModel<ViewPenaltyByIdViewModel>> GetPenaltyById(Guid id, CancellationToken ct)
        {
            var query = new GetPenaltyByIdQuery(id);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<ViewPenaltyByIdViewModel>.Failure(result.message, result.errorCode);
            }

            var mapped = _mapper.Map<ViewPenaltyByIdViewModel>(result.data);

            return ResponseViewModel<ViewPenaltyByIdViewModel>.Success(mapped);
        }
    }
}




