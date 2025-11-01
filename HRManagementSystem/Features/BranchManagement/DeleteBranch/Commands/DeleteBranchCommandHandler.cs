using HRManagementSystem.Features.Common.IsAnyChildAssignedGeneric;

namespace HRManagementSystem.Features.BranchManagement.DeleteBranch.Commands;

public sealed class DeleteBranchCommandHandler : RequestHandlerBase<DeleteBranchCommand,
        RequestResult<bool>, Branch, int>
{
    public DeleteBranchCommandHandler(RequestHandlerBaseParameters<Branch, int> parameters)
        : base(parameters) { }

    public override async Task<RequestResult<bool>> Handle(DeleteBranchCommand request, CancellationToken ct)
    {
        var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);
        if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.BranchNotFound);
        return RequestResult<bool>.Success(isDeleted);
    }
}
