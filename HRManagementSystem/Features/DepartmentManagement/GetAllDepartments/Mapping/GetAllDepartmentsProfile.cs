namespace HRManagementSystem.Features.DepartmentManagement.GetAllDepartments.Mapping
{
    public class GetAllDepartmentsProfile : Profile
    {
        public GetAllDepartmentsProfile()
        {
            CreateMap<Department, GetAllDepartmentsDto>()
             .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.Name));

            CreateMap<GetAllDepartmentsDto, GetAllDepartmentsResponseViewModel>();
        }
    }
}
