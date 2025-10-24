using AutoMapper;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.CityManagement.AddCity.Commands;
using HRManagementSystem.Features.CityManagement.GetCityById;

namespace HRManagementSystem.Features.Common.AddressManagement.AddCity.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            // Map AddCityCommand -> City (لـ Add Handler)
            CreateMap<AddCityCommand, City>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StateId, opt => opt.MapFrom(src => src.StateId));

            // Map City -> GetCityByIdDto (لـ GetById Handler)
            CreateMap<City, GetCityByIdDto>();

            CreateMap<GetCityByIdDto, GetCityByIdViewModel>();
        }
    }
}
