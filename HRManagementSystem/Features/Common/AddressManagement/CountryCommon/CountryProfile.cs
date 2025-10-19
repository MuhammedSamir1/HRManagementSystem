using AutoMapper;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.ViewModels;

namespace HRManagementSystem.Features.Common.AddressManagement.CountryCommon
{
    public sealed class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, ViewCountryDto>();

            CreateMap<ViewCountryDto, ViewCountryViewModel>().ReverseMap();
        }
    }
}
