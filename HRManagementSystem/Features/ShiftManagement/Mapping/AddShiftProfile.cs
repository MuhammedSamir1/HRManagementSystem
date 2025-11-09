using HRManagementSystem.Features.Common.Dtos;
using HRManagementSystem.Features.ShiftManagement.AddShift;
using HRManagementSystem.Features.ShiftManagement.AddShift.Commands;

namespace HRManagementSystem.Features.ShiftManagement.Mapping
{
    public sealed class AddShiftProfile : Profile
    {
        public AddShiftProfile()
        {
            CreateMap<AddShiftCommand, Shift>()
             .ForMember(d => d.Name,
                 o => o.MapFrom(s => s.Name.Trim()))
             .ForMember(d => d.StartTime,
                 o => o.MapFrom(s => s.StartTime))
             .ForMember(d => d.EndTime,
                 o => o.MapFrom(s => s.EndTime));


            CreateMap<Shift, CreatedIdDto>()
                .ForMember(d => d.Id,
                    o => o.MapFrom(s => s.Id));

            CreateMap<AddShiftCommand, AddShiftViewModel>().ReverseMap();
        }
    }
}

