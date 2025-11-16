using HRManagementSystem.Common.Views;
using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.PayrollCommon;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.GetAllOvertimeRates.Queries
{
    public sealed class GetAllOvertimeRatesQueryHandler :
         RequestHandlerBase<GetAllOvertimeRatesQuery, RequestResult<PagedList<OvertimeRateDto>>, OvertimeRate, Guid>
    {
        public GetAllOvertimeRatesQueryHandler(RequestHandlerBaseParameters<OvertimeRate, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<PagedList<OvertimeRateDto>>> Handle(GetAllOvertimeRatesQuery request, CancellationToken ct)
        {
            var query = _generalRepo.GetAll().AsNoTracking();

            if (!request.IncludeInactive)
                query = query.Where(x => x.IsActive);

            if (request.DayType.HasValue)
                query = query.Where(x => x.DayType == request.DayType.Value);

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var searchTerm = request.Search.Trim();
                query = query.Where(x =>
                    EF.Functions.Like(x.Name, $"%{searchTerm}%") ||
                    EF.Functions.Like(x.Description, $"%{searchTerm}%"));
            }

            query = ApplySorting(query, request.SortBy, request.SortDirection);

            var pagedList = await PagedList<OvertimeRateDto>.CreateAsync(
                query,
                request.PageNumber,
                request.PageSize,
                _mapper,
                ct);

            return RequestResult<PagedList<OvertimeRateDto>>.Success(pagedList);
        }

        private IQueryable<OvertimeRate> ApplySorting(IQueryable<OvertimeRate> query, string? sortBy, string? sortDirection)
        {
            var direction = (sortDirection ?? "asc").ToLowerInvariant();
            var sort = (sortBy ?? "name").Trim().ToLowerInvariant();

            return (sort, direction) switch
            {
                ("ratefactor", "desc") or ("multiplier", "desc") => query.OrderByDescending(x => x.Multiplier),
                ("ratefactor", _) or ("multiplier", _) => query.OrderBy(x => x.Multiplier),
                ("createdat", "desc") => query.OrderByDescending(x => x.CreatedAt),
                ("createdat", _) => query.OrderBy(x => x.CreatedAt),
                ("name", "desc") => query.OrderByDescending(x => x.Name),
                _ => query.OrderBy(x => x.Name)
            };
        }
    }
}

