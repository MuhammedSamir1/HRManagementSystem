using HRManagementSystem.Features.CompanyManagement.AddCompany.Commands;

namespace HRManagementSystem.Features.CompanyManagement.AddCompany.Mapping
{
    public class AddCompanyProfile : Profile
    {
        public AddCompanyProfile()
        {
            CreateMap<AddCompanyCommand, Company>()
                .ForMember(dest => dest.OrganizationId,
                           opt => opt.MapFrom(src => src.organizationId))

                .ForMember(dest => dest.Name,
                           opt => opt.MapFrom(src => src.name.Trim() ?? string.Empty))

                .ForMember(dest => dest.Code,
                           opt => opt.MapFrom(src => src.code.Trim() ?? string.Empty))

                .ForMember(dest => dest.Description,
                           opt => opt.MapFrom(src => src.description.Trim()))

                .ForMember(dest => dest.Organization,
                           opt => opt.Ignore())

                .ForMember(dest => dest.Branches,
                           opt => opt.Ignore());
        }
    }
}
