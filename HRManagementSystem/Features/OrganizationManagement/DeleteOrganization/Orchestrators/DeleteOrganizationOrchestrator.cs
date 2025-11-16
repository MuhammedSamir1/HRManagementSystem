namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Orchestrators;

public sealed record DeleteOrganizationOrchestrator(Guid Id) : IRequest<RequestResult<bool>>;


