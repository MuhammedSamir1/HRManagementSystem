using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetAllBonuses;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetAllBonuses.Queries
{
    public sealed record GetAllBonusesQuery() : IRequest<RequestResult<PagedList<ViewBonusDto>>>;

    public class GetAllBonusesQueryHandler : RequestHandlerBase<GetAllBonusesQuery, RequestResult<PagedList<ViewBonusDto>>, Bonus, int>
    {
        public GetAllBonusesQueryHandler(RequestHandlerBaseParameters<Bonus, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<PagedList<ViewBonusDto>>> Handle(GetAllBonusesQuery request, CancellationToken ct)
        {
            var bonuses = await _generalRepo.GetAllAsync(ct);
            var mapped = _mapper.Map<PagedList<ViewBonusDto>>(bonuses);
            return RequestResult<PagedList<ViewBonusDto>>.Success(mapped);
        }
    }
}
