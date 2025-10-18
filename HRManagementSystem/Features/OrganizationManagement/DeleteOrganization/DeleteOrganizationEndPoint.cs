using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization
{
    public class DeleteOrganizationEndPoint : BaseEndPoint<DeleteOrganizationViewModel, ResponseViewModel<bool>>
    {
        public DeleteOrganizationEndPoint(EndPointBaseParameters<DeleteOrganizationViewModel> parameters)
            : base(parameters) { }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> DeleteOrganization(DeleteOrganizationViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);

            var isDeleted = await _mediator.Send(new DeleteOrganizationCommand(model.Id));
            if (!isDeleted.isSuccess) return ResponseViewModel<bool>.Failure(ErrorCode.OrganizationWasNotDeleted);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Organization Deleted Successfully!");
        }
    }
}
