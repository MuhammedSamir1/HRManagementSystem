namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Common.ViewModels
{
    public record ViewHolidayViewModel(
     Guid Id,
     string Name,
     DateTime StartDate,
     DateTime EndDate,
     bool IsMandatory,
     string Type,
     int DurationInDays);
}

