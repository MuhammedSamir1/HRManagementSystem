using HRManagementSystem.Features.ShiftManagement.UpdateShift;
using HRManagementSystem.Features.ShiftManagement.UpdateShift.Commands;

namespace HRManagementSystem.Features.ShiftManagement.Mapping
{
    public sealed class UpdateShiftProfile : Profile
    {
        public UpdateShiftProfile()
        {
            CreateMap<UpdateShiftCommand, Shift>()
                .ForMember(d => d.Id,
              o => o.MapFrom(s => s.Id))
          .ForMember(d => d.Name,
              o => o.MapFrom(s => s.Name.Trim()))
          .ForMember(d => d.StartTime,
              o => o.MapFrom(s => s.StartTime))
          .ForMember(d => d.EndTime,
              o => o.MapFrom(s => s.EndTime));


            CreateMap<UpdateShiftCommand, UpdateShiftViewModel>().ReverseMap();
        }
    }
}

