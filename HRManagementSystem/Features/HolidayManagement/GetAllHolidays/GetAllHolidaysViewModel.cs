namespace HRManagementSystem.Features.HolidayManagement.GetAllHolidays
{
    public record GetAllHolidaysViewModel(
     //  الفلترة
     string? Name,
     int? CompanyId,
     bool? IsMandatory,

     //  Pagination  (  Base)
     int PageNumber,
     int PageSize,
     string? SortBy,
     string? SortDirection);
}
