using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetEndOfServiceById.Queries
{
    public sealed record GetEndOfServiceByIdQuery(int Id) : IRequest<RequestResult<ViewEndOfServiceByIdDto>>;

    public class GetEndOfServiceByIdQueryHandler : RequestHandlerBase<GetEndOfServiceByIdQuery, RequestResult<ViewEndOfServiceByIdDto>, EndOfService, int>
    {
        public GetEndOfServiceByIdQueryHandler(RequestHandlerBaseParameters<EndOfService, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewEndOfServiceByIdDto>> Handle(GetEndOfServiceByIdQuery request, CancellationToken ct)
        {
            var endOfService = await _generalRepo.GetByIdAsync(request.Id, ct);

            if (endOfService == null)
                return RequestResult<ViewEndOfServiceByIdDto>.Failure("End Of Service not found.", ErrorCode.NotFound);

            var mapped = _mapper.Map<ViewEndOfServiceByIdDto>(endOfService);
            return RequestResult<ViewEndOfServiceByIdDto>.Success(mapped);
        }
    }
}
