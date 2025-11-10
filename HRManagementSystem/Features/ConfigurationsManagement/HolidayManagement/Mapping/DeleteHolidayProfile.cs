using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.DeleteHoliday;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.DeleteHoliday.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Mapping
{
    public class DeleteHolidayProfile : Profile
    {
        public DeleteHolidayProfile()
        {
            CreateMap<DeleteHolidayViewModel, DeleteHolidayCommand>()
                .ForCtorParam("id", opt => opt.MapFrom(src => src.Id));
        }
    }
}
