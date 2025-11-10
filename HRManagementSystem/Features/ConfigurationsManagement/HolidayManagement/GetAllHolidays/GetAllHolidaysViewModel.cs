namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.GetAllHolidays
{
    public record GetAllHolidaysViewModel(
     //  ???????
     string? Name,
     int? CompanyId,
     bool? IsMandatory,

     //  Pagination  (  Base)
     int PageNumber,
     int PageSize,
     string? SortBy,
     string? SortDirection);
}
