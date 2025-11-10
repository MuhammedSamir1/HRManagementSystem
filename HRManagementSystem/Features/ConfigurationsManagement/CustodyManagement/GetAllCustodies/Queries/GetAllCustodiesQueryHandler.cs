using HRManagementSystem.Common.Views;
using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.CustodyCommon.Dtos;

namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.GetAllCustodies.Queries
{
    public sealed class GetAllCustodiesQueryHandler :
    RequestHandlerBase<GetAllCustodiesQuery, RequestResult<PagedList<ViewCustodyDto>>, Custody, int>
    {
        public GetAllCustodiesQueryHandler(
            RequestHandlerBaseParameters<Custody, int> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<PagedList<ViewCustodyDto>>> Handle(
            GetAllCustodiesQuery request,
            CancellationToken ct)
        {

            var query = _generalRepo.GetAll()
                .Where(c => !c.IsDeleted);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                //  ??? ItemName ?? SerialNumber
                query = query.Where(c =>
                    c.ItemName.Contains(request.SearchTerm) ||
                    c.SerialNumber.Contains(request.SearchTerm));
            }

            if (request.EmployeeId.HasValue && request.EmployeeId.Value > 0)
            {

                query = query.Where(c => c.EmployeeId == request.EmployeeId.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                query = query.Where(c => c.Status == request.Status);
            }


            var orderedQuery = query.OrderByDescending(c => c.HandoverDate);


            var pagedList = await PagedList<ViewCustodyDto>.CreateAsync(
                source: orderedQuery,
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                mapper: _mapper,
                ct: ct
            );

            // 5. ?????? ?? ??????? ????????
            if (!pagedList.Items.Any() && request.PageNumber > 1 && pagedList.TotalCount > 0)
            {
                return RequestResult<PagedList<ViewCustodyDto>>.Failure(
                    "??? ?????? ??????? ??? ???? ?? ?? ????? ??? ??????.",
                    ErrorCode.NotFound);
            }

            return RequestResult<PagedList<ViewCustodyDto>>.Success(pagedList);
        }
    }
}
