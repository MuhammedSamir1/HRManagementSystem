using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.HolidayManagement.Common.DTOs;
using HRManagementSystem.Features.HolidayManagement.GetHolidayById;

namespace HRManagementSystem.Features.HolidayManagement.GetAllHolidays.Queries
{
    public record GetAllHolidaysQuery(
     string? Name,
     int? CompanyId,
     bool? IsMandatory) : GetPagedListQueryBase<ViewHolidayDto>;
}
