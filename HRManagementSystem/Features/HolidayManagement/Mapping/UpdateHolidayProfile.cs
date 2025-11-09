using HRManagementSystem.Features.HolidayManagement.UpdateHoliday.Command;
using HRManagementSystem.Features.HolidayManagement.UpdateHoliday;

namespace HRManagementSystem.Features.HolidayManagement.Mapping
{
    public class UpdateHolidayProfile : Profile
    {
        public UpdateHolidayProfile()
        {
            // Mapping من ViewModel إلى Command
            CreateMap<UpdateHolidayRequestViewModel, UpdateHolidayCommand>();
        }
    }
}
