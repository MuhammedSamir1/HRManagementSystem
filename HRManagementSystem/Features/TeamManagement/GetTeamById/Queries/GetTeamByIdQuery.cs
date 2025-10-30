using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.TeamManagement.GetTeamById.Queries
{
    public sealed record GetTeamByIdQuery(int Id) : IRequest<RequestResult<ViewTeamByIdDto>>;

    public sealed class GetTeamByIdQueryHandler : RequestHandlerBase<GetTeamByIdQuery,
        RequestResult<ViewTeamByIdDto>, Team, int>
    {
        public GetTeamByIdQueryHandler(RequestHandlerBaseParameters<Team, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewTeamByIdDto>> Handle(GetTeamByIdQuery request, CancellationToken ct)
        {
            var team = await _generalRepo.Get(x => x.Id == request.Id && !x.IsDeleted, ct)
                .ProjectTo<ViewTeamByIdDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(ct);

            if (team is null)
                return RequestResult<ViewTeamByIdDto>.Failure(ErrorCode.TeamNotFound);

            return RequestResult<ViewTeamByIdDto>.Success(team);
        }
    }
}
