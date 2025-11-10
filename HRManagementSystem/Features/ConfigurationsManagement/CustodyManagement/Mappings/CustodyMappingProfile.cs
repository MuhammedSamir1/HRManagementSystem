using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.CustodyCommon.Dtos;
using HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.AddCustody.Commands;
using HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.GetAllCustodies;
using HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.GetAllCustodies.Queries;
using HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.UpdateCustody;
using HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.UpdateCustody.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.Mappings
{
    public class CustodyMappingProfile : Profile
    {
        public CustodyMappingProfile()
        {
            // =======================================================
            // 1. Mappings   (Create)
            // =======================================================

            CreateMap<AddCustodyCommand, Custody>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.Employee, opt => opt.Ignore());

            // =======================================================
            // 2. Mappings   (Update)
            // =======================================================


            CreateMap<UpdateCustodyViewModel, UpdateCustodyCommand>();

            // =======================================================
            // 3. Mappings    (Retrieve)
            // =======================================================


            CreateMap<Custody, ViewCustodyDto>()

                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.Name))

                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId));



            CreateMap<GetAllCustodiesViewModel, GetAllCustodiesQuery>();
        }
    }
}
