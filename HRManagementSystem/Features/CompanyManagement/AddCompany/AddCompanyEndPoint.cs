using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.CompanyManagement.AddCompany.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.CompanyManagement.AddCompany
{
    public class AddCompanyEndPoint : BaseEndPoint<AddCompanyRequestViewModel, ResponseViewModel<bool>>
    {
        public AddCompanyEndPoint(EndPointBaseParameters<AddCompanyRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost("add")]
        public async Task<ResponseViewModel<bool>> AddOrganization([FromQuery] AddCompanyRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new AddCompanyCommand(
                                                    model.organizationId,
                                                    model.Name,
                                                    model.code,
                                                    model.Descreption), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Company Added Successfully!");
        }
    }
}
