using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Common.Views;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetAllEndOfServices.Queries
{
    public sealed record GetAllEndOfServicesQuery() : IRequest<RequestResult<PagedList<ViewEndOfServiceDto>>>;

    public class GetAllEndOfServicesQueryHandler : RequestHandlerBase<GetAllEndOfServicesQuery, RequestResult<PagedList<ViewEndOfServiceDto>>, EndOfService, int>
    {
        public GetAllEndOfServicesQueryHandler(RequestHandlerBaseParameters<EndOfService, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<PagedList<ViewEndOfServiceDto>>> Handle(GetAllEndOfServicesQuery request, CancellationToken ct)
        {
            var query = _generalRepo.Get(x => !x.IsDeleted, ct);

            var pagedList = await PagedList<ViewEndOfServiceDto>.CreateAsync(
                query,
                1,
                100,
                _mapper,
                ct
            );

            return RequestResult<PagedList<ViewEndOfServiceDto>>.Success(pagedList);
        }
    }
}
