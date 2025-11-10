using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.AddHoliday;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.AddHoliday.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Mapping
{
    public class AddHolidayProfile : Profile
    {
        public AddHolidayProfile()
        {
            // 1. Mapping ?? ViewModel ??? Command
            CreateMap<AddHolidayRequestViewModel, AddHolidayCommand>();

            // 2. Mapping ?? Command ??? Entity
            CreateMap<AddHolidayCommand, Holiday>();
        }
    }
}
