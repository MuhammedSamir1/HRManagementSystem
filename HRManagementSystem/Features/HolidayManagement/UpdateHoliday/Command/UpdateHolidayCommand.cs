using HRManagementSystem.Data.Models.HolidayEntity;

namespace HRManagementSystem.Features.HolidayManagement.UpdateHoliday.Command
{
    public record UpdateHolidayCommand(
     int Id,
     string Name,
     DateTime StartDate,
     DateTime EndDate,
     bool IsMandatory,
     HolidayType Type,
     int? CompanyId) : IRequest<RequestResult<bool>>;
}
