namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Common.DTOs
{
    public record ViewHolidayDto(
    Guid Id,
    string Name,
    DateTime StartDate,
    DateTime EndDate,
    bool IsMandatory,
    string Type,
    int DurationInDays);
}

