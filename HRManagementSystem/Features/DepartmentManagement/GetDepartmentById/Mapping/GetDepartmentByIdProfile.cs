using AutoMapper;
using HRManagementSystem.Data.Models;

namespace HRManagementSystem.Features.DepartmentManagement.GetDepartmentById.Mapping
{
    public class GetDepartmentByIdProfile : Profile
    {
        public GetDepartmentByIdProfile()
        {
            CreateMap<Department, GetDepartmentByIdDto>()
    .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.Name));

            CreateMap<GetDepartmentByIdDto, GetDepartmentByIdResponseViewModel>();
        }
    }
}
