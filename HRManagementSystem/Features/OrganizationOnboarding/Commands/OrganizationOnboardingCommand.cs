namespace HRManagementSystem.Features.OrganizationOnboarding.Commands
{
    public record OrganizationOnboardingCommand(OrganizationOnboardingDto OnboardingDto) : IRequest<RequestResult<ViewOrganizationOnboardingDto>>;

}
