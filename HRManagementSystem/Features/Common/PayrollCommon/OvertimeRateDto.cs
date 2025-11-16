namespace HRManagementSystem.Features.Common.PayrollCommon
{
    public record OvertimeRateDto(
         Guid Id,
         string Name,
         decimal RateFactor, // ????? ????? (??? 1.5)
         string Description,
         bool IsActive);
}

