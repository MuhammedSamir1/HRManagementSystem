using AutoMapper.QueryableExtensions;
using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.Common.CustodyCommon.Dtos;

namespace HRManagementSystem.Features.CustodyManagement.GetAllCustodies.Queries
{
    public sealed class GetAllCustodiesQueryHandler :
    RequestHandlerBase<GetAllCustodiesQuery, RequestResult<PagedList<ViewCustodyDto>>, Custody, int>
    {
        private readonly IMapper _mapper;

        // حقن IMapper في الـ Constructor
        public GetAllCustodiesQueryHandler(
            RequestHandlerBaseParameters<Custody, int> parameters,
            IMapper mapper)
            : base(parameters)
        {
            _mapper = mapper;
        }

        public override async Task<RequestResult<PagedList<ViewCustodyDto>>> Handle(
            GetAllCustodiesQuery request,
            CancellationToken ct)
        {

            var query = _generalRepo.GetAll()
                .Where(c => !c.IsDeleted);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                //  على ItemName أو SerialNumber
                query = query.Where(c =>
                    c.ItemName.Contains(request.SearchTerm) ||
                    c.SerialNumber.Contains(request.SearchTerm));
            }

            if (request.EmployeeId.HasValue && request.EmployeeId.Value != Guid.Empty)
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

            // 5. التحقق من النتيجة النهائية
            if (!pagedList.Items.Any() && request.PageNumber > 1 && pagedList.TotalCount > 0)
            {
                return RequestResult<PagedList<ViewCustodyDto>>.Failure(
                    "رقم الصفحة المطلوب غير صالح أو لا يحتوي على بيانات.",
                    ErrorCode.NotFound);
            }

            return RequestResult<PagedList<ViewCustodyDto>>.Success(pagedList);
        }
    }
}
