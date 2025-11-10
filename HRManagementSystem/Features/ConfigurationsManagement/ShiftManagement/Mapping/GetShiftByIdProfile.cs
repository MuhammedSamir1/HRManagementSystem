using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetShiftById;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.Mapping
{
    public sealed class GetShiftByIdProfile : Profile
    {
        public GetShiftByIdProfile()
        {
            CreateMap<Shift, ViewShiftByIdDto>()
          .ForMember(d => d.Id,
              o => o.MapFrom(s => s.Id))
          .ForMember(d => d.Name,
              o => o.MapFrom(s => s.Name.Trim()))
          .ForMember(d => d.StartTime,
              o => o.MapFrom(s => s.StartTime))
          .ForMember(d => d.EndTime,
              o => o.MapFrom(s => s.EndTime));

            CreateMap<ViewShiftByIdDto, ViewShiftByIdViewModel>().ReverseMap();
        }
    }
}

