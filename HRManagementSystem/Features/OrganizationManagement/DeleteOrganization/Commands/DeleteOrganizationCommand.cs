namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Commands;
public sealed record DeleteOrganizationCommand(Guid Id) : IRequest<RequestResult<bool>>;


