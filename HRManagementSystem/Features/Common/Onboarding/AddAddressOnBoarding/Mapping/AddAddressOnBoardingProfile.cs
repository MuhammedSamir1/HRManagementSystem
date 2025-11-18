using HRManagementSystem.Features.Common.Onboarding.AddAddressOnBoarding.Dtos;
using HRManagementSystem.Features.Common.Onboarding.AddAddressOnBoarding.ViewModels;

namespace HRManagementSystem.Features.Common.Onboarding.AddAddressOnBoarding.Mapping
{
    public sealed class AddAddressOnBoardingProfile : Profile
    {
        public AddAddressOnBoardingProfile()
        {
            CreateMap<AddAddressOnBoardingRequestViewModel, AddAddressOnBoardingDto>();
            CreateMap<CountryOnBoardingViewModel, CountryOnBoardingDto>();
            CreateMap<StateOnBoardingViewModel, StateOnBoardingDto>();
            CreateMap<CityOnBoardingViewModel, CityOnBoardingDto>();
        }
    }
}


