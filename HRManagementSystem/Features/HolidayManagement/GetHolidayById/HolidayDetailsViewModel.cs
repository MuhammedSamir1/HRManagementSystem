namespace HRManagementSystem.Features.HolidayManagement.GetHolidayById
{
    public record HolidayDetailsViewModel(
      int Id,
      string Name,
      DateTime StartDate,
      DateTime EndDate,
      bool IsMandatory,
      string Type, // String for display
      int? CompanyId,
      int DurationInDays);
}
