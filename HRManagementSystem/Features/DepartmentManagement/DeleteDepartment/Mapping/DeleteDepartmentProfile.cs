using HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Commands;
using HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Orchestrators;

namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Mapping
{
    public class DeleteDepartmentProfile : Profile
    {
        public DeleteDepartmentProfile()
        {
            // Mapping من ViewModel إلى Command
            CreateMap<DeleteDepartmentRequestViewModel, DeleteDepartmentCommand>()
                .ForCtorParam("departmentId", opt => opt.MapFrom(src => src.departmentId));
            CreateMap<DeleteDepartmentRequestViewModel, DeleteDepartmentOrchestrator>()
                .ForCtorParam("departmentId", opt => opt.MapFrom(src => src.departmentId));
        }
    }
}
