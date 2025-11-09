using HRManagementSystem.Features.HolidayManagement.DeleteHoliday.Commands;
using HRManagementSystem.Features.HolidayManagement.DeleteHoliday;

namespace HRManagementSystem.Features.HolidayManagement.Mapping
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
