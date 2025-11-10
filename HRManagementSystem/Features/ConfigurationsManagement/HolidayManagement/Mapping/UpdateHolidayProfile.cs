using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.UpdateHoliday;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.UpdateHoliday.Command;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Mapping
{
    public class UpdateHolidayProfile : Profile
    {
        public UpdateHolidayProfile()
        {
            // Mapping ?? ViewModel ??? Command
            CreateMap<UpdateHolidayRequestViewModel, UpdateHolidayCommand>();
        }
    }
}
