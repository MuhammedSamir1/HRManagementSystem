namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Commands;
public sealed record DeleteOrganizationCommand(int Id) : IRequest<RequestResult<bool>>;

