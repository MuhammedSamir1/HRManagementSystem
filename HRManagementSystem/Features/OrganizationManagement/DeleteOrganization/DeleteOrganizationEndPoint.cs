using HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Orchestrators;

namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization
{
    [ApiGroup("Organization Management")]
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

            var isDeleted = await _mediator.Send(new DeleteOrganizationOrchestrator(model.Id));
            if (!isDeleted.isSuccess) return ResponseViewModel<bool>.Failure(isDeleted.message,
                ErrorCode.OrganizationWasNotDeleted);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Organization Deleted Successfully!");
        }
    }
}

