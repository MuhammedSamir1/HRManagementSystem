using HRManagementSystem.Features.DepartmentManagement.AddDepartment.Commands;

namespace HRManagementSystem.Features.DepartmentManagement.AddDepartment.Mapping
{
    public class AddDepartmentProfile : Profile
    {
        public AddDepartmentProfile()
        {
            CreateMap<AddDepartmentRequestViewModel, AddDepartmentCommand>()
                .ForCtorParam(nameof(AddDepartmentCommand.branchId).ToLower(), opt => opt.MapFrom(src => src.branchId))
                .ForCtorParam(nameof(AddDepartmentCommand.name).ToLower(), opt => opt.MapFrom(src => src.name))
                .ForCtorParam(nameof(AddDepartmentCommand.code).ToLower(), opt => opt.MapFrom(src => src.code))
                .ForCtorParam(nameof(AddDepartmentCommand.description).ToLower(), opt => opt.MapFrom(src => src.description));

            CreateMap<AddDepartmentCommand, Department>()
            .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.branchId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.code))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description));
        }
    }
}
