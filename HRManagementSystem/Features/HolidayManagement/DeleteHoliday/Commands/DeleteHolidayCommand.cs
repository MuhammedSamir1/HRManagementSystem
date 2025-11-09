namespace HRManagementSystem.Features.HolidayManagement.DeleteHoliday.Commands
{
    public record DeleteHolidayCommand(int Id) : IRequest<RequestResult<bool>>;
}
