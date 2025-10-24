using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.CompanyManagement.UpdateCompany.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.CompanyManagement.UpdateCompany
{
    public class UpdateCompanyEndPoint : BaseEndPoint<UpdateCompanyRequestViewModel, ResponseViewModel<bool>>
    {
        public UpdateCompanyEndPoint(EndPointBaseParameters<UpdateCompanyRequestViewModel> parameters) : base(parameters) { }

        [HttpPut("UpdateCompany")]
        public async Task<ResponseViewModel<bool>> UpdateCompany([FromQuery] UpdateCompanyRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new UpdateCompanyCommand(model.id, model.name, model.description));

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(result.isSuccess, "Organization Updated Successfully!");
        }
    }
}
