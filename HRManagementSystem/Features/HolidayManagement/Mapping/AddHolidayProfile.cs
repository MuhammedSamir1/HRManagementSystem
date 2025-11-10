using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.HolidayManagement.AddHoliday;
using HRManagementSystem.Features.HolidayManagement.AddHoliday.Commands;

namespace HRManagementSystem.Features.HolidayManagement.Mapping
{
    public class AddHolidayProfile : Profile
    {
        public AddHolidayProfile()
        {
            // 1. Mapping من ViewModel إلى Command
            CreateMap<AddHolidayRequestViewModel, AddHolidayCommand>();

            // 2. Mapping من Command إلى Entity
            CreateMap<AddHolidayCommand, Holiday>();
        }
    }
}
