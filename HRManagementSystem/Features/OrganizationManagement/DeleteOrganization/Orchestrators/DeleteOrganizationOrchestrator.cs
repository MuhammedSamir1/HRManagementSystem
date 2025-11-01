namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Orchestrators;

public sealed record DeleteOrganizationOrchestrator(int Id) : IRequest<RequestResult<bool>>;

