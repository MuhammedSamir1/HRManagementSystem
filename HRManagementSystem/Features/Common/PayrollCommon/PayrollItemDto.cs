namespace HRManagementSystem.Features.Common.PayrollCommon
{
    public record PayrollItemDto(
     int Id,
     string Name,
     PayrollItemType Type,
     CalculationType CalculationType,
     decimal Value,
     bool IsStatutory);
}
