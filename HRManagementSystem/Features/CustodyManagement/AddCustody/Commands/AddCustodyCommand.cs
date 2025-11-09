namespace HRManagementSystem.Features.CustodyManagement.AddCustody.Commands
{
    public sealed record AddCustodyCommand(
    string ItemName,
    string SerialNumber,
    Guid EmployeeId,
    DateTime HandoverDate) : IRequest<RequestResult<int>>;
}
