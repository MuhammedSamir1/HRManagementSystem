using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetAllPenalties.Queries
{
    public sealed record GetAllPenaltiesQuery() : IRequest<RequestResult<PagedList<ViewPenaltyDto>>>;

    public class GetAllPenaltiesQueryHandler : RequestHandlerBase<GetAllPenaltiesQuery, RequestResult<PagedList<ViewPenaltyDto>>, Penalty, int>
    {
        public GetAllPenaltiesQueryHandler(RequestHandlerBaseParameters<Penalty, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<PagedList<ViewPenaltyDto>>> Handle(GetAllPenaltiesQuery request, CancellationToken ct)
        {
            var penalties = await _generalRepo.GetAllAsync(ct);
            var mapped = _mapper.Map<PagedList<ViewPenaltyDto>>(penalties);
            return RequestResult<PagedList<ViewPenaltyDto>>.Success(mapped);
        }
    }
}
