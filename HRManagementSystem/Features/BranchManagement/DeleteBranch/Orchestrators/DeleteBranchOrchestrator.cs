namespace HRManagementSystem.Features.BranchManagement.DeleteBranch.Orchestrators;

public sealed record DeleteBranchOrchestrator(int Id) : IRequest<RequestResult<bool>>;

