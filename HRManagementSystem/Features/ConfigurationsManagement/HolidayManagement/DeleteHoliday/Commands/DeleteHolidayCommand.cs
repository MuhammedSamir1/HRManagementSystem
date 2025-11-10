namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.DeleteHoliday.Commands
{
    public record DeleteHolidayCommand(int Id) : IRequest<RequestResult<bool>>;
}
