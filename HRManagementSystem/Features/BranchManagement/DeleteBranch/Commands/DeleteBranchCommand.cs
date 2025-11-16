namespace HRManagementSystem.Features.BranchManagement.DeleteBranch.Commands;
public sealed record DeleteBranchCommand(Guid Id) : IRequest<RequestResult<bool>>;



