using AutoMapper;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.DepartmentManagement.UpdateDepartment.Commands;

namespace HRManagementSystem.Features.DepartmentManagement.UpdateDepartment.Mapping
{
    public class UpdateDepartmentProfile : Profile
    {
        public UpdateDepartmentProfile()
        {
   
            CreateMap<UpdateDepartmentRequestViewModel, UpdateDepartmentCommand>()
                .ForCtorParam("id", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("branchId", opt => opt.MapFrom(src => src.branchId))
                .ForCtorParam("name", opt => opt.MapFrom(src => src.name))
                .ForCtorParam("code", opt => opt.MapFrom(src => src.code))
                .ForCtorParam("description", opt => opt.MapFrom(src => src.description));

         
            CreateMap<UpdateDepartmentCommand, Department>()
                // عشان    الid موجود
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.branchId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.code))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description));
        }
    }
}
