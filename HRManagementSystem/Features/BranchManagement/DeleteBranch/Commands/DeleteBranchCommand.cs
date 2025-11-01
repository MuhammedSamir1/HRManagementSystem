using HRManagementSystem.Features.Common.IsAnyChildAssignedGeneric;

namespace HRManagementSystem.Features.BranchManagement.DeleteBranch.Commands;
public sealed record DeleteBranchCommand(int Id) : IRequest<RequestResult<bool>>;


