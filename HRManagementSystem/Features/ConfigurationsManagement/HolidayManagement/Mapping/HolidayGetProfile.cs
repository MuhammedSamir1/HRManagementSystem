using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Common.DTOs;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Common.ViewModels;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.GetAllHolidays;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.GetAllHolidays.Queries;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.GetHolidayById;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Mapping
{
    public class HolidayGetProfile : Profile
    {
        public HolidayGetProfile()
        {
            // Mapping ??  ???  ViewModel
            CreateMap<Holiday, HolidayDetailsViewModel>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.DurationInDays,
                           opt => opt.MapFrom(src => (int)(src.EndDate - src.StartDate).TotalDays + 1));
            CreateMap<ViewHolidayDto, ViewHolidayViewModel>();
            CreateMap<GetAllHolidaysViewModel, GetAllHolidaysQuery>();
        }
    }
}
