using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.Dtos;
using HRManagementSystem.Features.OrganizationManagement.AddOrganization.Commands;

namespace HRManagementSystem.Features.OrganizationOnboarding
{
    public class OrganizationOnboardingEndpoint : BaseEndPoint<OrganizationOnboardingRequestViewModel, ResponseViewModel<bool>>
    {
        public OrganizationOnboardingEndpoint(EndPointBaseParameters<OrganizationOnboardingRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> OrganizationOnboarding([FromBody] OrganizationOnboardingRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var address = _mapper.Map<AddOrganizationAddressDto>(model.Address);
            var currency = _mapper.Map<AddOrganizationCurrencyDto>(model.Currency);


            var result = await _mediator.Send(new AddOrganizationCommand(model.Name, model.LegalName,
                model.Description, model.Industry, model.DefaultTimezone, currency, address), ct);



            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Organization Added Successfully!");
        }
    }

}
