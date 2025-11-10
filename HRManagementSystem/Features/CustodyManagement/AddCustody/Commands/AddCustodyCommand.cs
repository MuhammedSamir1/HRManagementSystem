namespace HRManagementSystem.Features.CustodyManagement.AddCustody.Commands
{
    public sealed record AddCustodyCommand(
    string ItemName,
    string SerialNumber,
    int EmployeeId,
    DateTime HandoverDate) : IRequest<RequestResult<int>>;
}
