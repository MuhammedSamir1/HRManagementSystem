using AutoMapper;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtos.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtos.ViewModels;

namespace HRManagementSystem.Features.Common.AddressManagement.AddAddressDtos
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            // Address
            CreateMap<AddOrganizationAddressDto, Address>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Country, o => o.Ignore())
                .ForMember(d => d.State, o => o.Ignore())
                .ForMember(d => d.City, o => o.Ignore())
                .ForMember(d => d.Street, o => o.MapFrom(s => s.Street))
                .ForMember(d => d.ZipCode, o => o.MapFrom(s => s.ZipCode));

            CreateMap<AddOrganizationAddressDto, AddAddressViewModel>().ReverseMap();
        }
    }
}
