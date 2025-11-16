using HRManagementSystem.Features.Common.DeleteEntityCascade;
using HRManagementSystem.Features.Common.DeleteEntityCascade.Command;

namespace HRManagementSystem.Features.BranchManagement.DeleteBranch.Cascade;

public class DeleteBranchCascadeEndPoint : BaseEndPoint<DeleteEntityCascadeViewModel<Branch, Guid>, ResponseViewModel<bool>>
{
    public DeleteBranchCascadeEndPoint(EndPointBaseParameters<DeleteEntityCascadeViewModel<Branch, Guid>> parameters)
        : base(parameters) { }
    [HttpDelete("delete-cascade")]
    public async Task<ResponseViewModel<bool>> DeleteBranchCascade([FromQuery] DeleteEntityCascadeViewModel<Branch, Guid> model, CancellationToken ct)
    {
        var validationResult = ValidateRequest(model);
        if (!validationResult.isSuccess)
            return ResponseViewModel<bool>.Failure(validationResult.errorCode);
        var isDeleted = await _mediator.Send(new DeleteEntityCascadeCommand<Branch, Guid>(model.Id));
        if (!isDeleted.isSuccess)
            return ResponseViewModel<bool>.Failure(isDeleted.message, isDeleted.errorCode);
        return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Branch Deleted Successfully!");
    }
}
