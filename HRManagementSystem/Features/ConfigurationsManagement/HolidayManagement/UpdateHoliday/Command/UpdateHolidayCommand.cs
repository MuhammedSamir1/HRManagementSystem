namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.UpdateHoliday.Command
{
    public record UpdateHolidayCommand(
     Guid Id,
     string Name,
     DateTime StartDate,
     DateTime EndDate,
     bool IsMandatory,
     HolidayType Type) : IRequest<RequestResult<bool>>;
}

