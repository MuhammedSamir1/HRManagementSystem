using HRManagementSystem.Features.Common.AddressManagement.AddAddressOnBoarding.Dtos;

namespace HRManagementSystem.Features.Common.AddressManagement.AddAddressOnBoarding.Orchestrators
{
    public sealed record AddAddressOnBoardingOrchestrator(AddAddressOnBoardingDto Payload)
        : IRequest<RequestResult<bool>>;
}


