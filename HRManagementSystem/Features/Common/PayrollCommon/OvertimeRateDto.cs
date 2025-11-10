namespace HRManagementSystem.Features.Common.PayrollCommon
{
    public record OvertimeRateDto(
         int Id,
         string Name,
         decimal RateFactor, // معامل السعر (مثل 1.5)
         string Description,
         bool IsActive); 
}
