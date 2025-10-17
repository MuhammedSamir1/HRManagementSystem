using AutoMapper;
using HRManagementSystem.Data.Models;
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
           .ForMember(d => d.DefaultTimezone,
               o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.DefaultTimezone) ? null : s.DefaultTimezone.Trim()))
           .ForMember(d => d.DefaultCurrency,
               o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.DefaultCurrency) ? null : s.DefaultCurrency.Trim().ToUpperInvariant()))
           .ForMember(d => d.Address,
               o => o.MapFrom(s => s.AddressDto))
           .ForMember(d => d.AddressId, o => o.Ignore());

            CreateMap<AddOrganizationCommand, AddOrganizationViewModel>().ReverseMap();
        }
    }
}
