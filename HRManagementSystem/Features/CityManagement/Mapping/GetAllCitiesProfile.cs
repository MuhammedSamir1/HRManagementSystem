using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.CityManagement.GetAllCities;

namespace HRManagementSystem.Features.Common.AddressManagement.GetAllCities.Profiles
{
    public class GetAllCitiesProfile : Profile
    {
        public GetAllCitiesProfile()
        {
            // Map City -> GetAllCitiesDto
            CreateMap<City, ViewAllCitiesDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<ViewAllCitiesDto, ViewAllCitiesViewModel>().ReverseMap();
        }
    }
}
