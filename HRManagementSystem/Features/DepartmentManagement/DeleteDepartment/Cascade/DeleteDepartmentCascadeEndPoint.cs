using HRManagementSystem.Features.Common.DeleteEntityCascade;

using HRManagementSystem.Features.Common.DeleteEntityCascade.Command;

namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Cascade;

public class DeleteDepartmentCascadeEndPoint : BaseEndPoint<DeleteEntityCascadeViewModel<Department, int>, ResponseViewModel<bool>>
{
    public DeleteDepartmentCascadeEndPoint(EndPointBaseParameters<DeleteEntityCascadeViewModel<Department, int>> parameters)
        : base(parameters) { }
    [HttpDelete("delete-cascade")]
    public async Task<ResponseViewModel<bool>> DeleteDepartmentCascade([FromQuery] DeleteEntityCascadeViewModel<Department, int> model, CancellationToken ct)
    {
        var validationResult = ValidateRequest(model);
        if (!validationResult.isSuccess)
            return ResponseViewModel<bool>.Failure(validationResult.errorCode);
        var isDeleted = await _mediator.Send(new DeleteEntityCascadeCommand<Department, int>(model.Id));
        if (!isDeleted.isSuccess)
            return ResponseViewModel<bool>.Failure(isDeleted.message, isDeleted.errorCode);
        return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Department Deleted Successfully!");
    }
}
