namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.GetHolidayById
{
    public record HolidayDetailsViewModel(
      Guid Id,
      string Name,
      DateTime StartDate,
      DateTime EndDate,
      bool IsMandatory,
      string Type, // String for display
      int DurationInDays);
}

