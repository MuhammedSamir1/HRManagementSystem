using HRManagementSystem.Features.HolidayManagement.Common.DTOs;
using HRManagementSystem.Features.HolidayManagement.Common.ViewModels;
using HRManagementSystem.Features.HolidayManagement.GetAllHolidays.Queries;
using HRManagementSystem.Features.HolidayManagement.GetAllHolidays;
using HRManagementSystem.Features.HolidayManagement.GetHolidayById;

namespace HRManagementSystem.Features.HolidayManagement.Mapping
{
    public class HolidayGetProfile : Profile
    {
        public HolidayGetProfile()
        {
            // Mapping من  إلى  ViewModel
            CreateMap<Holiday, HolidayDetailsViewModel>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.DurationInDays,
                           opt => opt.MapFrom(src => (int)(src.EndDate - src.StartDate).TotalDays + 1));
            CreateMap<ViewHolidayDto, ViewHolidayViewModel>();
            CreateMap<GetAllHolidaysViewModel, GetAllHolidaysQuery>();
        }
    }
}
