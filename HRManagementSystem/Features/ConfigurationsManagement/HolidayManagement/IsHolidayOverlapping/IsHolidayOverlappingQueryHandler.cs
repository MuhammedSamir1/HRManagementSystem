using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.IsHolidayOverlapping
{
    public sealed class IsHolidayOverlappingQueryHandler : RequestHandlerBase<IsHolidayOverlappingQuery, RequestResult<bool>, Holiday, int>
    {
        public IsHolidayOverlappingQueryHandler(RequestHandlerBaseParameters<Holiday, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(IsHolidayOverlappingQuery request, CancellationToken ct)
        {
            // ????? ???????: Start1 <= End2 AND End1 >= Start2
            var isOverlapping = await _generalRepo
                .Get(h => h.Id != request.ExcludeHolidayId &&
                          h.CompanyId == request.CompanyId &&
                          request.StartDate <= h.EndDate &&
                          request.EndDate >= h.StartDate, ct)
                .AnyAsync(ct);

            if (isOverlapping)
            {
                return RequestResult<bool>.Failure("The specified dates overlap with an existing holiday.", ErrorCode.Conflict);
            }
            return RequestResult<bool>.Success(true);
        }
    }
}
