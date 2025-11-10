using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.PayrollCommon;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.AddPayrollItem.Commands;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.AddPayrollItem.ViewModels;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.UpdatePayrollItem.Commands;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.UpdatePayrollItem.ViewModels;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.AddOvertimeRate.Commands;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.AddOvertimeRate.ViewModels;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.UpdateOvertimeRate.Commands;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.UpdateOvertimeRate.ViewModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.Mapping
{
    public class PayrollMappingProfile : Profile
    {
        public PayrollMappingProfile()
        {
            CreateMap<AddPayrollItemViewModel, AddPayrollItemCommand>();
            CreateMap<AddPayrollItemCommand, PayrollItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

            CreateMap<PayrollItem, PayrollItemDto>(); // ??????? ??? ?????
            CreateMap<UpdatePayrollItemViewModel, UpdatePayrollItemCommand>();

            CreateMap<UpdatePayrollItemCommand, PayrollItem>()

                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());


            CreateMap<AddOvertimeRateViewModel, AddOvertimeRateCommand>();

            // Command -> Entity
            CreateMap<AddOvertimeRateCommand, OvertimeRate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());


            CreateMap<OvertimeRate, OvertimeRateDto>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => !src.IsDeleted))

               .ForMember(dest => dest.RateFactor, opt => opt.MapFrom(src => src.Multiplier))
               .ReverseMap()
               .ForMember(dest => dest.Multiplier, opt => opt.MapFrom(src => src.RateFactor));

            // ViewModel -> Command
            CreateMap<UpdateOvertimeRateViewModel, UpdateOvertimeRateCommand>();

            CreateMap<UpdateOvertimeRateCommand, OvertimeRate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

        }
    }
}
