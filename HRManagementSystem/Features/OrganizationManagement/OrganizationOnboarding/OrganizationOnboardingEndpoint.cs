using HRManagementSystem.Features.OrganizationManagement.OrganizationOnboarding.Commands;

namespace HRManagementSystem.Features.OrganizationManagement.OrganizationOnboarding
{
    [ApiGroup("Onboarding")]
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

