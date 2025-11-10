using HRManagementSystem.Features.Common.DeleteEntityCascade;
using HRManagementSystem.Features.Common.DeleteEntityCascade.Command;

using HRManagementSystem.Features.Common.DeleteEntityCascade.Command;

namespace HRManagementSystem.Features.BranchManagement.DeleteBranch.Cascade;

public class DeleteBranchCascadeEndPoint : BaseEndPoint<DeleteEntityCascadeViewModel<Branch, int>, ResponseViewModel<bool>>
{
    public DeleteBranchCascadeEndPoint(EndPointBaseParameters<DeleteEntityCascadeViewModel<Branch, int>> parameters)
        : base(parameters) { }
    [HttpDelete("delete-cascade")]
    public async Task<ResponseViewModel<bool>> DeleteBranchCascade([FromQuery] DeleteEntityCascadeViewModel<Branch, int> model, CancellationToken ct)
    {
        var validationResult = ValidateRequest(model);
        if (!validationResult.isSuccess)
            return ResponseViewModel<bool>.Failure(validationResult.errorCode);
        var isDeleted = await _mediator.Send(new DeleteEntityCascadeCommand<Branch, int>(model.Id));
        if (!isDeleted.isSuccess)
            return ResponseViewModel<bool>.Failure(isDeleted.message, isDeleted.errorCode);
        return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Branch Deleted Successfully!");
    }
}