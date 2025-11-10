using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetAllEndOfServices.Queries
{
    public sealed record GetAllEndOfServicesQuery() : IRequest<RequestResult<PagedList<ViewEndOfServiceDto>>>;

    public class GetAllEndOfServicesQueryHandler : RequestHandlerBase<GetAllEndOfServicesQuery, RequestResult<PagedList<ViewEndOfServiceDto>>, EndOfService, int>
    {
        public GetAllEndOfServicesQueryHandler(RequestHandlerBaseParameters<EndOfService, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<PagedList<ViewEndOfServiceDto>>> Handle(GetAllEndOfServicesQuery request, CancellationToken ct)
        {
            var endOfServices = await _generalRepo.GetAllAsync(ct);
            var mapped = _mapper.Map<PagedList<ViewEndOfServiceDto>>(endOfServices);
            return RequestResult<PagedList<ViewEndOfServiceDto>>.Success(mapped);
        }
    }
}
