using AutoMapper;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.ViewModels;

namespace HRManagementSystem.Features.CountryManagement.Mapping
{
    public class GetAllCountriesProfile : Profile
    {
        public GetAllCountriesProfile()
        {

            // 1) Entity -> DTO
            CreateMap<Country, ViewCountryDto>();

            // 2) DTO <-> VM
            CreateMap<ViewCountryDto, ViewCountryViewModel>()
                .ReverseMap();

            // 3) RequestResult<List<ViewCountryDto>> -> RequestResult<List<ViewCountryViewModel>>
            CreateMap<
                RequestResult<List<ViewCountryDto>>,
                RequestResult<List<ViewCountryViewModel>>
            >()
            .ForMember(dest => dest.data,
                       opt => opt.MapFrom(src => src.data));
        }
    }
}
