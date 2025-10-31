using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.Dtos;
using HRManagementSystem.Features.OrganizationManagement.AddOrganization.Commands;
using HRManagementSystem.Features.OrganizationOnboarding.Commands;

namespace HRManagementSystem.Features.OrganizationOnboarding
{
    public class OrganizationOnboardingEndpoint : BaseEndPoint<OrganizationOnboardingRequestViewModel, ResponseViewModel<bool>>
    {
        public OrganizationOnboardingEndpoint(EndPointBaseParameters<OrganizationOnboardingRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost("onboarding")]
        public async Task<ResponseViewModel<ViewOrganizationOnboardingDto>> OrganizationOnboarding(
       [FromBody] OrganizationOnboardingRequestViewModel model,
       CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<ViewOrganizationOnboardingDto>.Failure(
                    validationResult.message, validationResult.errorCode);

            var onboardingDto = _mapper.Map<OrganizationOnboardingDto>(model);

            var result = await _mediator.Send(new OrganizationOnboardingCommand(onboardingDto), ct);

            if (!result.isSuccess)
                return ResponseViewModel<ViewOrganizationOnboardingDto>.Failure(result.message, result.errorCode);

            return ResponseViewModel<ViewOrganizationOnboardingDto>.Success(
                result.data,
                "Organization onboarding completed successfully!"
            );
        }
    }
}
