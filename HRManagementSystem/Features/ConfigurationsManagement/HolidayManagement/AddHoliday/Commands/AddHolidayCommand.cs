namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.AddHoliday.Commands
{
    public record AddHolidayCommand(
     string Name,
     DateTime StartDate,
     DateTime EndDate,
     bool IsMandatory,
     HolidayType Type,
     int? CompanyId) : IRequest<RequestResult<bool>>;
}
