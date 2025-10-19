using AutoMapper;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CityCommon.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.CityCommon.ViewModels;

namespace HRManagementSystem.Features.Common.AddressManagement.CityCommon
{
    public sealed class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, ViewCityDto>();

            CreateMap<ViewCityDto, ViewCityViewModel>().ReverseMap();
        }
    }
}
