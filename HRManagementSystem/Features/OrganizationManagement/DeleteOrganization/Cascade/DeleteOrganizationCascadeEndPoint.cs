using HRManagementSystem.Features.Common.DeleteEntityCascade;
using HRManagementSystem.Features.Common.DeleteEntityCascade.Command;

namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Cascade;

public class DeleteOrganizationCascadeEndPoint : BaseEndPoint<DeleteEntityCascadeViewModel<
    Organization, int>, ResponseViewModel<bool>>
{
    public DeleteOrganizationCascadeEndPoint(EndPointBaseParameters<DeleteEntityCascadeViewModel<Organization, int>> parameters)
       : base(parameters) { }
    [HttpDelete("delete-cascade")]
    public async Task<ResponseViewModel<bool>> DeleteOrganizationCascade([FromQuery] DeleteEntityCascadeViewModel<Organization, int> model, CancellationToken ct)
    {
        var validationResult = ValidateRequest(model);
        if (!validationResult.isSuccess)
            return ResponseViewModel<bool>.Failure(validationResult.errorCode);
        var isDeleted = await _mediator.Send(new DeleteEntityCascadeCommand<Organization, int>(model.Id));
        if (!isDeleted.isSuccess)
            return ResponseViewModel<bool>.Failure(isDeleted.message, isDeleted.errorCode);
        return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Organization Deleted Successfully!");
    }
}
