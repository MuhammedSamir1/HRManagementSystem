using HRManagementSystem.Features.OrganizationManagement.UpdateOrganization;
using HRManagementSystem.Features.OrganizationManagement.UpdateOrganization.Commands;

namespace HRManagementSystem.Features.OrganizationManagement.Mapping
{
    public sealed class UpdateOrganizationProfile : Profile
    {
        public UpdateOrganizationProfile()
        {
            CreateMap<UpdateOrganizationCommand, Organization>()
           .ForMember(d => d.Id,
               o => o.MapFrom(s => s.Id))
           .ForMember(d => d.Name,
               o => o.MapFrom(s => s.Name.Trim()))
           .ForMember(d => d.LegalName,
               o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.LegalName) ? null : s.LegalName.Trim()))
           .ForMember(d => d.Industry,
               o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Industry) ? null : s.Industry.Trim()))
           .ForMember(d => d.Description,
               o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Descreption) ? null : s.Descreption.Trim()))

           .ForMember(d => d.Address,
               o => o.MapFrom(s => s.AddressDto))
           .ForMember(d => d.AddressId, o => o.Ignore())
           .ForMember(d => d.DefaultTimezone, o => o.Ignore());

            CreateMap<UpdateOrganizationCommand, UpdateOrganizationViewModel>().ReverseMap();
        }
    }
}
