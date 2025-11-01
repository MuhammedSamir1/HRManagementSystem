namespace HRManagementSystem.Features.OrganizationManagement.OrganizationOnboarding.Commands
{
    public record OrganizationOnboardingCommand(OrganizationOnboardingDto OnboardingDto) : IRequest<RequestResult<ViewOrganizationOnboardingDto>>;

}
