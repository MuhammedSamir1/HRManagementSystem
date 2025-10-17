using AutoMapper;
using HRManagementSystem.Data.Models.AddressEntity;

namespace HRManagementSystem.Features.Common.AddressManagement
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddAddressDto, Address>()
             .ForMember(d => d.Id, o => o.Ignore())
             .ForMember(d => d.Country,
                 o => o.MapFrom(s => s.Country.Trim()))
             .ForMember(d => d.City,
                 o => o.MapFrom(s => s.City.Trim()))
             .ForMember(d => d.Street,
                 o => o.MapFrom(s =>
                     string.IsNullOrWhiteSpace(s.Street) ? null : s.Street.Trim()))
             .ForMember(d => d.ZipCode,
                 o => o.MapFrom(s =>
                     string.IsNullOrWhiteSpace(s.ZipCode) ? null : s.ZipCode.Trim()));

            CreateMap<AddAddressDto, AddAddressViewModel>().ReverseMap();
        }
    }
}
