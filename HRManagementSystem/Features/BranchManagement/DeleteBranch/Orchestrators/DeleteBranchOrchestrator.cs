namespace HRManagementSystem.Features.BranchManagement.DeleteBranch.Orchestrators;

public sealed record DeleteBranchOrchestrator(Guid Id) : IRequest<RequestResult<bool>>;


