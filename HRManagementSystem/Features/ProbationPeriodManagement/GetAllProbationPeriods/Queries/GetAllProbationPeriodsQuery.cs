using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ProbationPeriodManagement.GetAllProbationPeriods.Queries
{
    public sealed record GetAllProbationPeriodsQuery : IRequest<RequestResult<IEnumerable<ViewProbationPeriodDto>>>;

    public sealed class GetAllProbationPeriodsQueryHandler : RequestHandlerBase<GetAllProbationPeriodsQuery,
        RequestResult<IEnumerable<ViewProbationPeriodDto>>, ProbationPeriod, int>
    {
        public GetAllProbationPeriodsQueryHandler(RequestHandlerBaseParameters<ProbationPeriod, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<IEnumerable<ViewProbationPeriodDto>>> Handle(GetAllProbationPeriodsQuery request, CancellationToken ct)
        {
            var probationPeriods = await _generalRepo.Get(x => !x.IsDeleted, ct)
               .ProjectTo<ViewProbationPeriodDto>(_mapper.ConfigurationProvider)
               .ToListAsync(ct);

            if (probationPeriods is null)
                return RequestResult<IEnumerable<ViewProbationPeriodDto>>.Failure(ErrorCode.ProbationPeriodNotFound);

            return RequestResult<IEnumerable<ViewProbationPeriodDto>>.Success(probationPeriods);
        }
    }
}

