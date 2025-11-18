using HRManagementSystem.Features.Common.Onboarding.AddAddressOnBoarding.Dtos;

namespace HRManagementSystem.Features.Common.Onboarding.AddAddressOnBoarding.Orchestrators
{
    public sealed record AddAddressOnBoardingOrchestrator(AddAddressOnBoardingDto Payload)
        : IRequest<RequestResult<bool>>;
}


