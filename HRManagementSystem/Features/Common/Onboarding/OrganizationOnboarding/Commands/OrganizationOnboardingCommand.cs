using HRManagementSystem.Features.Common.Onboarding.OrganizationOnboarding;

namespace HRManagementSystem.Features.Common.Onboarding.OrganizationOnboarding.Commands
{
    public record OrganizationOnboardingCommand(OrganizationOnboardingDto OnboardingDto) : IRequest<RequestResult<ViewOrganizationOnboardingDto>>;

}
