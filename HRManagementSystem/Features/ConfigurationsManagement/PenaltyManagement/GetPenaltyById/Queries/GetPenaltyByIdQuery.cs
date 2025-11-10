using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetPenaltyById.Queries
{
    public sealed record GetPenaltyByIdQuery(int Id) : IRequest<RequestResult<ViewPenaltyByIdDto>>;

    public class GetPenaltyByIdQueryHandler : RequestHandlerBase<GetPenaltyByIdQuery, RequestResult<ViewPenaltyByIdDto>, Penalty, int>
    {
        public GetPenaltyByIdQueryHandler(RequestHandlerBaseParameters<Penalty, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewPenaltyByIdDto>> Handle(GetPenaltyByIdQuery request, CancellationToken ct)
        {
            var penalty = await _generalRepo.GetByIdAsync(request.Id, ct);

            if (penalty == null)
                return RequestResult<ViewPenaltyByIdDto>.Failure("Penalty not found.", ErrorCode.NotFound);

            var mapped = _mapper.Map<ViewPenaltyByIdDto>(penalty);
            return RequestResult<ViewPenaltyByIdDto>.Success(mapped);
        }
    }
}
