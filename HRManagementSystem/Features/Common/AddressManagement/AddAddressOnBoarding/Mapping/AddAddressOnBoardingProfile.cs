using HRManagementSystem.Features.Common.AddressManagement.AddAddressOnBoarding.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressOnBoarding.ViewModels;

namespace HRManagementSystem.Features.Common.AddressManagement.AddAddressOnBoarding.Mapping
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


