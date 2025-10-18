using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.UpdateCurrencyDtosAndVms.Dtos;
using HRManagementSystem.Features.OrganizationManagement.UpdateOrganization.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.OrganizationManagement.UpdateOrganization
{
    public class UpdateOrganizationEndPoint : BaseEndPoint<UpdateOrganizationViewModel, ResponseViewModel<bool>>
    {
        public UpdateOrganizationEndPoint(EndPointBaseParameters<UpdateOrganizationViewModel> parameters) : base(parameters) { }

        [HttpPut("update")]
        public async Task<ResponseViewModel<bool>> UpdateOrganization([FromQuery] UpdateOrganizationViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var address = _mapper.Map<UpdateOrganizationAddressDto>(model.Address);
            var currency = _mapper.Map<UpdateOrganizationCurrencyDto>(model.Currency);
            var result = await _mediator.Send(new UpdateOrganizationCommand(model.Id,model.Name, model.LegalName, model.Industry,
                model.Descreption, currency, address));

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(result.isSuccess, "Organization Updated Successfully!");
        }
    }
}
