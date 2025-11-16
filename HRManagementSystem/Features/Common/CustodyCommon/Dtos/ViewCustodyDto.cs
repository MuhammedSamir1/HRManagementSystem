namespace HRManagementSystem.Features.Common.CustodyCommon.Dtos
{
    public record ViewCustodyDto(
      Guid Id,
      string ItemName,
      string SerialNumber,
      DateTime HandoverDate,
      DateTime? ReturnDate,
      string Status);
}

