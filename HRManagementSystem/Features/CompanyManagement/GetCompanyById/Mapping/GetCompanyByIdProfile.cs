using AutoMapper;
using HRManagementSystem.Data.Models;

namespace HRManagementSystem.Features.CompanyManagement.GetCompanyById.Mapping
{
    public class GetCompanyByIdProfile : Profile
    {
        public GetCompanyByIdProfile()
        {
            CreateMap<Company, GetCompanyByIdDto>()
                .ForMember(dest => dest.OrganizationName, options => options.MapFrom(src => src.Organization.Name));

            CreateMap<GetCompanyByIdDto, GetCompanyByIdResponseViewModel>();
        }
    }
}
