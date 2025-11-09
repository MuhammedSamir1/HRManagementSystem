using HRManagementSystem.Features.Common.Dtos;
using HRManagementSystem.Features.DepartmentManagement.AddDepartment.Commands;

namespace HRManagementSystem.Features.DepartmentManagement.AddDepartment.Mapping
{
    public class AddDepartmentProfile : Profile
    {
        public AddDepartmentProfile()
        {
            CreateMap<AddDepartmentCommand, Department>()
            .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.branchId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.code))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description));

            CreateMap<Department, CreatedIdDto>()
               .ForMember(d => d.Id,
                   o => o.MapFrom(s => s.Id));
        }
    }
}
