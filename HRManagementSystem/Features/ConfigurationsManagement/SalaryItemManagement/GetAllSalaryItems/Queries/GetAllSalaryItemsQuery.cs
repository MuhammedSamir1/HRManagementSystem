using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetAllSalaryItems.Queries
{
    public sealed record GetAllSalaryItemsQuery() : IRequest<RequestResult<PagedList<ViewSalaryItemDto>>>;

    public class GetAllSalaryItemsQueryHandler : RequestHandlerBase<GetAllSalaryItemsQuery, RequestResult<PagedList<ViewSalaryItemDto>>, SalaryItem, int>
    {
        public GetAllSalaryItemsQueryHandler(RequestHandlerBaseParameters<SalaryItem, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<PagedList<ViewSalaryItemDto>>> Handle(GetAllSalaryItemsQuery request, CancellationToken ct)
        {
            var salaryItems = await _generalRepo.GetAllAsync(ct);
            var mapped = _mapper.Map<PagedList<ViewSalaryItemDto>>(salaryItems);
            return RequestResult<PagedList<ViewSalaryItemDto>>.Success(mapped);
        }
    }
}
