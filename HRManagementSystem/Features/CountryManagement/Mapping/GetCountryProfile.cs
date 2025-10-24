using AutoMapper;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.ViewModels;

namespace HRManagementSystem.Features.CountryManagement.Mapping
{
    public sealed class GetCountryProfile : Profile
    {
        public GetCountryProfile()
        {

            CreateMap<Country, ViewCountryDto>();

            CreateMap<ViewCountryDto, ViewCountryViewModel>()
                .ReverseMap();
        }
    }
}
