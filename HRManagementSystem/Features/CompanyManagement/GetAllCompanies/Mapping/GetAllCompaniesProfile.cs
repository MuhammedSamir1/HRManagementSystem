using AutoMapper;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.CompanyManagement.GetAllCompany;

namespace HRManagementSystem.Features.CompanyManagement.GetAllCompanies.Mapping
{
    public class GetAllCompaniesProfile : Profile
    {
        public GetAllCompaniesProfile()
        {
            CreateMap<Company, GetAllCompaniesDto>()
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.Organization.Name));

            CreateMap<GetAllCompaniesDto, GetAllCompaniesResponseViewModel>();
        }
    }
}
