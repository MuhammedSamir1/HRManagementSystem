using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.TeamManagement.GetAllTeams.Queries
{
    public sealed record GetAllTeamsQuery : IRequest<RequestResult<IEnumerable<ViewTeamDto>>>;

    public sealed class GetAllTeamsQueryHandler : RequestHandlerBase<GetAllTeamsQuery,
        RequestResult<IEnumerable<ViewTeamDto>>, Team, Guid>
    {
        public GetAllTeamsQueryHandler(RequestHandlerBaseParameters<Team, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<IEnumerable<ViewTeamDto>>> Handle(GetAllTeamsQuery request, CancellationToken ct)
        {
            var teams = await _generalRepo.Get(x => !x.IsDeleted, ct)
               .ProjectTo<ViewTeamDto>(_mapper.ConfigurationProvider)
               .ToListAsync(ct);

            if (teams is null)
                return RequestResult<IEnumerable<ViewTeamDto>>.Failure(ErrorCode.TeamNotFound);

            return RequestResult<IEnumerable<ViewTeamDto>>.Success(teams);
        }
    }
}
