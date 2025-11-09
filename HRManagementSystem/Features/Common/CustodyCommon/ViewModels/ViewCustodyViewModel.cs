namespace HRManagementSystem.Features.Common.CustodyCommon.ViewModels
{
    public record ViewCustodyViewModel(
      int Id,
      string ItemName,
      string SerialNumber,
      DateTime HandoverDate,
      DateTime? ReturnDate,
      string Status,
      int EmployeeId);
}
