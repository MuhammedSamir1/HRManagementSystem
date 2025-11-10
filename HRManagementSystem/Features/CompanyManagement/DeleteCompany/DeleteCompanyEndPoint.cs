using HRManagementSystem.Features.CompanyManagement.DeleteCompany.Orchestrator;

namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany
{
    public class DeleteCompanyEndPoint : BaseEndPoint<DeleteCompanyRequestViewModel, ResponseViewModel<bool>>
    {
        public DeleteCompanyEndPoint(EndPointBaseParameters<DeleteCompanyRequestViewModel> parameters)
                 : base(parameters) { }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> DeleteOrganization(DeleteCompanyRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);

            var isDeleted = await _mediator.Send(new DeleteCompanyOrchestrator(model.companyId));
            if (!isDeleted.isSuccess) return ResponseViewModel<bool>.Failure(isDeleted.message, isDeleted.errorCode);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Company Deleted Successfully!");
        }
    }
}
