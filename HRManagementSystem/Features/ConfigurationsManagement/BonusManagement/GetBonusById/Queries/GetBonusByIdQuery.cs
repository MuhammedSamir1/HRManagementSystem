using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetBonusById.Queries
{
    public sealed record GetBonusByIdQuery(int Id) : IRequest<RequestResult<ViewBonusByIdDto>>;

    public class GetBonusByIdQueryHandler : RequestHandlerBase<GetBonusByIdQuery, RequestResult<ViewBonusByIdDto>, Bonus, int>
    {
        public GetBonusByIdQueryHandler(RequestHandlerBaseParameters<Bonus, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewBonusByIdDto>> Handle(GetBonusByIdQuery request, CancellationToken ct)
        {
            var bonus = await _generalRepo.GetByIdAsync(request.Id, ct);

            if (bonus == null)
                return RequestResult<ViewBonusByIdDto>.Failure("Bonus not found.", ErrorCode.NotFound);

            var mapped = _mapper.Map<ViewBonusByIdDto>(bonus);
            return RequestResult<ViewBonusByIdDto>.Success(mapped);
        }
    }
}
