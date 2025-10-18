using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.Dtos;
using HRManagementSystem.Features.OrganizationManagement.AddOrganization.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.OrganizationManagement.AddOrginzation
{
    public class AddOrganizationEndPoint : BaseEndPoint<AddOrganizationViewModel, ResponseViewModel<bool>>
    {
        public AddOrganizationEndPoint(EndPointBaseParameters<AddOrganizationViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost("add")]
        public async Task<ResponseViewModel<bool>> AddOrganization([FromQuery] AddOrganizationViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var address = _mapper.Map<AddOrganizationAddressDto>(model.Address);
            var currency = _mapper.Map<AddOrganizationCurrencyDto>(model.Currency);
            var result = await _mediator.Send(new AddOrganizationCommand(model.Name, model.LegalName,
                model.Descreption, model.Industry, model.DefaultTimezone, currency, address), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Organization Added Successfully!");
        }
    }
}
