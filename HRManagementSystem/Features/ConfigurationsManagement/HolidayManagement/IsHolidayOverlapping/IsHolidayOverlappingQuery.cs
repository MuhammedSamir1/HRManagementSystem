namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.IsHolidayOverlapping
{
    public sealed record IsHolidayOverlappingQuery(
      DateTime StartDate,
      DateTime EndDate,
      Guid? ExcludeHolidayId = null) : IRequest<RequestResult<bool>>;
}

