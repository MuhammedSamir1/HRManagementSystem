using AutoMapper;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.ViewModels;
using HRManagementSystem.Features.Common.AddressManagement.GetAddressDtosAndVms.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.GetAddressDtosAndVms.ViewModels;

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

            // Add Branch Address
            CreateMap<AddBranchAddressDto, Address>()
               .ForMember(d => d.Id, o => o.Ignore())
               .ForMember(d => d.Country, o => o.Ignore())
               .ForMember(d => d.State, o => o.Ignore())
               .ForMember(d => d.City, o => o.Ignore())
               .ForMember(d => d.Street, o => o.MapFrom(s => s.Street))
               .ForMember(d => d.ZipCode, o => o.MapFrom(s => s.ZipCode));

            // View Organization AddressDto
            CreateMap<Address, ViewOrganizationAddressDto>()
             .ForCtorParam("Country", o => o.MapFrom(a => a.Country))
             .ForCtorParam("City", o => o.MapFrom(a => a.City))
             .ForCtorParam("State", o => o.MapFrom(a => a.State))
             .ForCtorParam("Street", o => o.MapFrom(a => a.Street))
             .ForCtorParam("ZipCode", o => o.MapFrom(a => a.ZipCode));


            // View Branch AddressDto
            CreateMap<Address, ViewBranchAddressDto>()
             .ForCtorParam("Country", o => o.MapFrom(a => a.Country))
             .ForCtorParam("City", o => o.MapFrom(a => a.City))
             .ForCtorParam("State", o => o.MapFrom(a => a.State))
             .ForCtorParam("Street", o => o.MapFrom(a => a.Street))
             .ForCtorParam("ZipCode", o => o.MapFrom(a => a.ZipCode));


            // Dtos <-> ViewModels
            CreateMap<AddOrganizationAddressDto, AddOrganizationAddressViewModel>().ReverseMap();
            CreateMap<ViewOrganizationAddressDto, ViewOrganizationAddressViewModel>().ReverseMap();
            CreateMap<AddBranchAddressDto, AddBranchAddressViewModel>().ReverseMap();
            CreateMap<ViewBranchAddressDto, ViewBranchAddressViewModel>().ReverseMap();

        }
    }
}
