using AutoMapper;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.ViewModels;
using HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.ViewModels;

namespace HRManagementSystem.Features.Common.AddressManagement
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            // Add Organization Address
            CreateMap<AddOrganizationAddressDto, Address>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Country, o => o.Ignore())
                .ForMember(d => d.State, o => o.Ignore())
                .ForMember(d => d.City, o => o.Ignore())
                .ForMember(d => d.Street, o => o.MapFrom(s => s.Street))
                .ForMember(d => d.ZipCode, o => o.MapFrom(s => s.ZipCode));

            // Update Organization Address
            CreateMap<UpdateOrganizationAddressDto, Address>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Country, o => o.Ignore())
                .ForMember(d => d.State, o => o.Ignore())
                .ForMember(d => d.City, o => o.Ignore())
                .ForMember(d => d.Street, o => o.MapFrom(s => s.Street))
                .ForMember(d => d.ZipCode, o => o.MapFrom(s => s.ZipCode));


            CreateMap<AddOrganizationAddressDto, AddOrganizationAddressViewModel>().ReverseMap();
            CreateMap<UpdateOrganizationAddressDto, UpdateOrganizationAddressViewModel>().ReverseMap();
        }
    }
}
