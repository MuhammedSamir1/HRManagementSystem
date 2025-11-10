namespace HRManagementSystem.Features.CustodyManagement.UpdateCustody.Commands
{
    public sealed record UpdateCustodyCommand(
    int Id,
    string? ItemName,
    string? SerialNumber,
    int? EmployeeId,
    DateTime? HandoverDate,
    DateTime? ReturnDate,
    string? Status) : IRequest<RequestResult<bool>>;
}
