namespace HRManagementSystem.Features.HolidayManagement.IsHolidayOverlapping
{
    public sealed record IsHolidayOverlappingQuery(
      DateTime StartDate,
      DateTime EndDate,
      int? CompanyId,
      int ExcludeHolidayId = 0) : IRequest<RequestResult<bool>>;
}
