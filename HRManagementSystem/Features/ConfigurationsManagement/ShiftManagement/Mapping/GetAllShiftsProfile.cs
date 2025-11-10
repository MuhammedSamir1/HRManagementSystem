using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetAllShifts;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.Mapping
{
    public sealed class GetAllShiftsProfile : Profile
    {
        public GetAllShiftsProfile()
        {
            CreateMap<Shift, ViewShiftDto>()
          .ForMember(d => d.Id,
              o => o.MapFrom(s => s.Id))
          .ForMember(d => d.Name,
              o => o.MapFrom(s => s.Name.Trim()))
          .ForMember(d => d.StartTime,
              o => o.MapFrom(s => s.StartTime))
          .ForMember(d => d.EndTime,
              o => o.MapFrom(s => s.EndTime));

            CreateMap<ViewShiftDto, ViewShiftViewModel>().ReverseMap();
        }
    }
}

