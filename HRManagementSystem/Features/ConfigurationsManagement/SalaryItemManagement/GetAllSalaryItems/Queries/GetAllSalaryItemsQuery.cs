using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Common.Views;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetAllSalaryItems.Queries
{
    public sealed record GetAllSalaryItemsQuery() : IRequest<RequestResult<PagedList<ViewSalaryItemDto>>>;

    public class GetAllSalaryItemsQueryHandler : RequestHandlerBase<GetAllSalaryItemsQuery, RequestResult<PagedList<ViewSalaryItemDto>>, SalaryItem, int>
    {
        public GetAllSalaryItemsQueryHandler(RequestHandlerBaseParameters<SalaryItem, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<PagedList<ViewSalaryItemDto>>> Handle(GetAllSalaryItemsQuery request, CancellationToken ct)
        {
            var query = _generalRepo.Get(x => !x.IsDeleted, ct);

            var pagedList = await PagedList<ViewSalaryItemDto>.CreateAsync(
                query,
                1,
                100,
                _mapper,
                ct
            );

            return RequestResult<PagedList<ViewSalaryItemDto>>.Success(pagedList);
        }
    }
}
