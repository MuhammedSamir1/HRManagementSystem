using HRManagementSystem.Features.Common.DeleteEntityCascade;

using HRManagementSystem.Features.Common.DeleteEntityCascade.Command;

namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Cascade;

public class DeleteCompanyCascadeEndPoint : BaseEndPoint<DeleteEntityCascadeViewModel<Company, int>, ResponseViewModel<bool>>
{
    public DeleteCompanyCascadeEndPoint(EndPointBaseParameters<DeleteEntityCascadeViewModel<Company, int>> parameters)
        : base(parameters) { }
    [HttpDelete("delete-cascade")]
    public async Task<ResponseViewModel<bool>> DeleteCompanyCascade([FromQuery] DeleteEntityCascadeViewModel<Company, int> model, CancellationToken ct)
    {
        var validationResult = ValidateRequest(model);
        if (!validationResult.isSuccess)
            return ResponseViewModel<bool>.Failure(validationResult.errorCode);
        var isDeleted = await _mediator.Send(new DeleteEntityCascadeCommand<Company, int>(model.Id));
        if (!isDeleted.isSuccess)
            return ResponseViewModel<bool>.Failure(isDeleted.message, isDeleted.errorCode);
        return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Company Deleted Successfully!");
    }
}
