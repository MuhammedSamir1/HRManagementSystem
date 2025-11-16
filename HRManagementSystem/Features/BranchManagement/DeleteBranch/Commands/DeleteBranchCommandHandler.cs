namespace HRManagementSystem.Features.BranchManagement.DeleteBranch.Commands;

public sealed class DeleteBranchCommandHandler : RequestHandlerBase<DeleteBranchCommand,
        RequestResult<bool>, Branch, Guid>
{
    public DeleteBranchCommandHandler(RequestHandlerBaseParameters<Branch, Guid> parameters)
        : base(parameters) { }

    public override async Task<RequestResult<bool>> Handle(DeleteBranchCommand request, CancellationToken ct)
    {
        var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);
        if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.BranchNotFound);
        return RequestResult<bool>.Success(isDeleted);
    }
}

