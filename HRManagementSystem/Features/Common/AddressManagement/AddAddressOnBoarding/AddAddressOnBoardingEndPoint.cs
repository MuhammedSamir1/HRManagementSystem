using HRManagementSystem.Features.Common.AddressManagement.AddAddressOnBoarding.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressOnBoarding.Orchestrators;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressOnBoarding.ViewModels;

namespace HRManagementSystem.Features.Common.AddressManagement.AddAddressOnBoarding
{
    [ApiGroup("Onboarding")]
    public sealed class AddAddressOnBoardingEndPoint
        : BaseEndPoint<AddAddressOnBoardingRequestViewModel, ResponseViewModel<bool>>
    {
        public AddAddressOnBoardingEndPoint(EndPointBaseParameters<AddAddressOnBoardingRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost("/address-onboarding")]
        public async Task<ResponseViewModel<bool>> OnboardAddresses([FromBody] AddAddressOnBoardingRequestViewModel model, CancellationToken ct)
        {
            var validation = ValidateRequest(model);
            if (!validation.isSuccess)
                return ResponseViewModel<bool>.Failure(validation.errorCode);

            var dto = _mapper.Map<AddAddressOnBoardingDto>(model);
            var result = await _mediator.Send(new AddAddressOnBoardingOrchestrator(dto), ct);

            return result.isSuccess
                ? ResponseViewModel<bool>.Success(result.data, result.message)
                : ResponseViewModel<bool>.Failure(result.message, result.errorCode);
        }
    }
}


