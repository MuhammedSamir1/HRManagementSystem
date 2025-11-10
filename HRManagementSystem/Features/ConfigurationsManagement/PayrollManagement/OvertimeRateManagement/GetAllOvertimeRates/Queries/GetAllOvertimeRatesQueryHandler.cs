using HRManagementSystem.Common.Views;
using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.PayrollCommon;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.GetAllOvertimeRates.Queries
{
    public sealed class GetAllOvertimeRatesQueryHandler :
         RequestHandlerBase<GetAllOvertimeRatesQuery, RequestResult<PagedList<OvertimeRateDto>>, OvertimeRate, int>
    {
        private readonly IMapper _mapper;
        private const int MaxPageSize = 100;

        public GetAllOvertimeRatesQueryHandler(
            RequestHandlerBaseParameters<OvertimeRate, int> parameters,
            IMapper mapper)
            : base(parameters)
        {
            _mapper = mapper;
        }

        public override async Task<RequestResult<PagedList<OvertimeRateDto>>> Handle(GetAllOvertimeRatesQuery request, CancellationToken ct)
        {
            // 1. ??? ??? ??????? ???? ???
            var pageNumber = Math.Max(request.PageNumber, 1);
            var pageSize = Math.Clamp(request.PageSize, 1, MaxPageSize);

            // 2. ???? ????????? ?? ???????????? ?????
            // GetAll() => IQueryable<OvertimeRate>
            var query = _generalRepo.GetAll().AsNoTracking();

            // 3. ?????
            if (!request.IncludeInactive)
                query = query.Where(x => x.IsActive);

            if (request.DayType.HasValue)
                query = query.Where(x => x.DayType == request.DayType.Value);

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var s = request.Search.Trim();
                query = query.Where(x =>
                    EF.Functions.Like(x.Name, $"%{s}%") ||
                    EF.Functions.Like(x.Description, $"%{s}%"));
            }

            // 4. ??? ???
            query = ApplySorting(query, request.SortBy, request.SortDirection);

            // 5. ??????? ??? PagedList.CreateAsync ??????? ???? ?? ProjectTo ???????
            var pagedList = await PagedList<OvertimeRateDto>.CreateAsync(
                source: query,
                pageNumber: pageNumber,
                pageSize: pageSize,
                mapper: _mapper,
                ct: ct);

            // 6. ????? ???????
            return RequestResult<PagedList<OvertimeRateDto>>.Success(pagedList, "?? ??? ????? ?????? ????? ??????? ?????.");
        }

        // ???? ?????? ????? ????? (???? ?????? ??????? ???)
        private IQueryable<OvertimeRate> ApplySorting(IQueryable<OvertimeRate> query, string? sortBy, string? sortDirection)
        {
            var dir = (sortDirection ?? "asc").ToLowerInvariant();
            var sort = (sortBy ?? "name").Trim().ToLowerInvariant();

            return (sort, dir) switch
            {
                ("ratefactor", "desc") or ("multiplier", "desc") => query.OrderByDescending(x => x.Multiplier),
                ("ratefactor", _) or ("multiplier", _) => query.OrderBy(x => x.Multiplier),

                ("createdat", "desc") => query.OrderByDescending(x => x.CreatedAt),
                ("createdat", _) => query.OrderBy(x => x.CreatedAt),

                ("name", "desc") => query.OrderByDescending(x => x.Name),
                ("name", _) => query.OrderBy(x => x.Name),

                _ => query.OrderBy(x => x.Name),
            };
        }
    }
}
