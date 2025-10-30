using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.ViewModels;

namespace HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms
{
    public sealed class UpdateAddressProfile : Profile
    {
        public UpdateAddressProfile()
        {
            // Update Organization Address
            CreateMap<UpdateOrganizationAddressDto, Address>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Country, o => o.Ignore())
                .ForMember(d => d.State, o => o.Ignore())
                .ForMember(d => d.City, o => o.Ignore())
                .ForMember(d => d.Street, o => o.MapFrom(s => s.Street))
                .ForMember(d => d.ZipCode, o => o.MapFrom(s => s.ZipCode));

            // Update Branch Address
            CreateMap<UpdateBranchAddressDto, Address>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Country, o => o.Ignore())
                .ForMember(d => d.State, o => o.Ignore())
                .ForMember(d => d.City, o => o.Ignore())
                .ForMember(d => d.Street, o => o.MapFrom(s => s.Street))
                .ForMember(d => d.ZipCode, o => o.MapFrom(s => s.ZipCode));


            // Dtos  <->  ViewModels
            CreateMap<UpdateOrganizationAddressDto, UpdateOrganizationAddressViewModel>().ReverseMap();
            CreateMap<UpdateBranchAddressDto, UpdateBranchAddressViewModel>().ReverseMap();

        }
    }
}
