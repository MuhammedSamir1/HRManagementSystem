using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Common.Views;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetAllBonuses.Queries
{
    public sealed record GetAllBonusesQuery() : IRequest<RequestResult<PagedList<ViewBonusDto>>>;

    public class GetAllBonusesQueryHandler : RequestHandlerBase<GetAllBonusesQuery, RequestResult<PagedList<ViewBonusDto>>, Bonus, int>
    {
        public GetAllBonusesQueryHandler(RequestHandlerBaseParameters<Bonus, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<PagedList<ViewBonusDto>>> Handle(GetAllBonusesQuery request, CancellationToken ct)
        {
            var query = _generalRepo.Get(x => !x.IsDeleted, ct);

            var pagedList = await PagedList<ViewBonusDto>.CreateAsync(
                query,
                1,
                100,
                _mapper,
                ct
            );

            return RequestResult<PagedList<ViewBonusDto>>.Success(pagedList);
        }
    }
}
