namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.UpdateCustody.Commands
{
    public sealed record UpdateCustodyCommand(
    Guid Id,
    string? ItemName,
    string? SerialNumber,
    DateTime? HandoverDate,
    DateTime? ReturnDate,
    string? Status) : IRequest<RequestResult<bool>>;
}

