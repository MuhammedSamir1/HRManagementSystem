namespace HRManagementSystem.Features.Common.CustodyCommon.ViewModels
{
    public record ViewCustodyViewModel(
      Guid Id,
      string ItemName,
      string SerialNumber,
      DateTime HandoverDate,
      DateTime? ReturnDate,
      string Status);
}

