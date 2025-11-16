using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Common.DTOs;

namespace HRManagementSystem.Features.Configurations.HolidayManagement.GetAllHolidays.Queries
{
    public record GetAllHolidaysQuery(
     string? Name,
     bool? IsMandatory) : GetPagedListQueryBase<ViewHolidayDto>;
}

