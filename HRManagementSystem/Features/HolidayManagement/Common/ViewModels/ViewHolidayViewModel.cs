namespace HRManagementSystem.Features.HolidayManagement.Common.ViewModels
{
    public record ViewHolidayViewModel(
     int Id,
     string Name,
     DateTime StartDate,
     DateTime EndDate,
     bool IsMandatory,
     string Type,
     int? CompanyId,
     int DurationInDays);
}
