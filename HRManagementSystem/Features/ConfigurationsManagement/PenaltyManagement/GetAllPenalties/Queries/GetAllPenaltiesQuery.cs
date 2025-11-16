using HRManagementSystem.Common.Views;
using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetAllPenalties.Queries
{
    public sealed record GetAllPenaltiesQuery() : IRequest<RequestResult<PagedList<ViewPenaltyDto>>>;

    public class GetAllPenaltiesQueryHandler : RequestHandlerBase<GetAllPenaltiesQuery, RequestResult<PagedList<ViewPenaltyDto>>, Penalty, Guid>
    {
        public GetAllPenaltiesQueryHandler(RequestHandlerBaseParameters<Penalty, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<PagedList<ViewPenaltyDto>>> Handle(GetAllPenaltiesQuery request, CancellationToken ct)
        {
            var query = _generalRepo.Get(x => !x.IsDeleted, ct);

            var pagedList = await PagedList<ViewPenaltyDto>.CreateAsync(
                query,
                1,
                100,
                _mapper,
                ct
            );

            return RequestResult<PagedList<ViewPenaltyDto>>.Success(pagedList);
        }
    }
}

