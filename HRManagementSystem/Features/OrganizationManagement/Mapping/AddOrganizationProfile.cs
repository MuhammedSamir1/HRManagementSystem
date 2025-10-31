using HRManagementSystem.Features.Common.Dtos;
using HRManagementSystem.Features.OrganizationManagement.AddOrganization.Commands;

namespace HRManagementSystem.Features.OrganizationManagement.Mapping
{
    public class AddOrganizationProfile : Profile
    {
        public AddOrganizationProfile()
        {
            CreateMap<AddOrganizationCommand, Organization>()
           .ForMember(d => d.Name,
               o => o.MapFrom(s => s.Name.Trim()))
           .ForMember(d => d.LegalName,
               o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.LegalName) ? null : s.LegalName.Trim()))
           .ForMember(d => d.Industry,
               o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Industry) ? null : s.Industry.Trim()))
           .ForMember(d => d.Description,
               o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Description) ? null : s.Description.Trim()))

           .ForMember(d => d.Address,
               o => o.MapFrom(s => s.AddressDto))
           .ForMember(d => d.AddressId, o => o.Ignore())
           .ForMember(d => d.DefaultTimezone, o => o.Ignore())
           .ForMember(d => d.DefaultTimezone, o => o.MapFrom(s => s.DefaultTimezone));

            CreateMap<Organization, CreatedIdDto>()
                .ForMember(d => d.Id,
                    o => o.MapFrom(s => s.Id));


            CreateMap<AddOrganizationCommand, AddOrganizationViewModel>().ReverseMap();
        }
    }
}
