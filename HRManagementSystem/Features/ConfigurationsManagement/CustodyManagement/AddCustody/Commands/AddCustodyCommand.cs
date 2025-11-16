namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.AddCustody.Commands
{
    public sealed record AddCustodyCommand(
    string ItemName,
    string SerialNumber,
    DateTime HandoverDate) : IRequest<RequestResult<Guid>>;
}

