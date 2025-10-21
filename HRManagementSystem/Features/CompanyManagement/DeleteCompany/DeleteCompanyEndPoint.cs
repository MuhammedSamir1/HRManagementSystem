using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;
using Microsoft.AspNetCore.Mvc;

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

            var isDeleted = await _mediator.Send(new DeleteCompanyCommand(model.companyId));
            if (!isDeleted.isSuccess) return ResponseViewModel<bool>.Failure(ErrorCode.NotFound);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Company Deleted Successfully!");
        }
    }
}
