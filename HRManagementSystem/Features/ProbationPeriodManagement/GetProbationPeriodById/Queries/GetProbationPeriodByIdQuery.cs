using AutoMapper.QueryableExtensions;
using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ProbationPeriodManagement.GetProbationPeriodById.Queries
{
    public sealed record GetProbationPeriodByIdQuery(int Id) : IRequest<RequestResult<ViewProbationPeriodByIdDto>>;

    public sealed class GetProbationPeriodByIdQueryHandler : RequestHandlerBase<GetProbationPeriodByIdQuery,
        RequestResult<ViewProbationPeriodByIdDto>, ProbationPeriod, int>
    {
        public GetProbationPeriodByIdQueryHandler(RequestHandlerBaseParameters<ProbationPeriod, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewProbationPeriodByIdDto>> Handle(GetProbationPeriodByIdQuery request, CancellationToken ct)
        {
            var probationPeriod = await _generalRepo.Get(x => x.Id == request.Id && !x.IsDeleted, ct)
                .ProjectTo<ViewProbationPeriodByIdDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(ct);

            if (probationPeriod is null)
                return RequestResult<ViewProbationPeriodByIdDto>.Failure(ErrorCode.ProbationPeriodNotFound);

            return RequestResult<ViewProbationPeriodByIdDto>.Success(probationPeriod);
        }
    }
}

