namespace HRManagementSystem.Features.Common.PayrollCommon
{
    public record PayrollItemDto(
     Guid Id,
     string Name,
     PayrollItemType Type,
     CalculationType CalculationType,
     decimal Value,
     bool IsStatutory);
}

