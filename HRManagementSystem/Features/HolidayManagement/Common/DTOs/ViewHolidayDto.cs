namespace HRManagementSystem.Features.HolidayManagement.Common.DTOs
{
    public record ViewHolidayDto(
    int Id,
    string Name,
    DateTime StartDate,
    DateTime EndDate,
    bool IsMandatory,
    string Type,
    int? CompanyId,
    int DurationInDays);
}
