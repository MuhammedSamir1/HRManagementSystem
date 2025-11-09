using HRManagementSystem.Data.Models.HolidayEntity;

namespace HRManagementSystem.Features.HolidayManagement.AddHoliday.Commands
{
    public record AddHolidayCommand(
     string Name,
     DateTime StartDate,
     DateTime EndDate,
     bool IsMandatory,
     HolidayType Type,
     int? CompanyId) : IRequest<RequestResult<bool>>;
}
