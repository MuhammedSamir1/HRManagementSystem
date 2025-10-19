using AutoMapper;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.OrganizationManagement.GetOrganizationById;

namespace HRManagementSystem.Features.OrganizationManagement.Mapping
{
    public class GetOrganizationProfile : Profile
    {
        public GetOrganizationProfile()
        {
            CreateMap<Organization, ViewOrganizationDto>()
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.LegalName, o => o.MapFrom(s => s.LegalName))
            .ForMember(d => d.Industry, o => o.MapFrom(s => s.Industry))
            .ForMember(d => d.Descreption, o => o.MapFrom(s => s.Description))
            .ForMember(d => d.DefaultTimezone, o => o.MapFrom(s => s.DefaultTimezone))
            .ForMember(d => d.Currency, o => o.MapFrom(s => s.DefaultCurrency))
            .ForMember(d => d.Address, o => o.MapFrom(s => s.Address));
           
            CreateMap<ViewOrganizationDto, ViewOrganizationViewModel>().ReverseMap();
        }
    }
}
