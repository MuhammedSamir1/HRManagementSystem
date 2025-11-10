namespace HRManagementSystem.Features.Common.CustodyCommon.Dtos
{
    public record ViewCustodyDto(
      int Id,
      string ItemName,
      string SerialNumber,
      DateTime HandoverDate,
      DateTime? ReturnDate,
      string Status,
      Guid EmployeeId,
        string EmployeeName
        );
}
