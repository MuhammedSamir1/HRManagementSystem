namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.DeleteHoliday.Commands
{
    public record DeleteHolidayCommand(Guid Id) : IRequest<RequestResult<bool>>;
}

