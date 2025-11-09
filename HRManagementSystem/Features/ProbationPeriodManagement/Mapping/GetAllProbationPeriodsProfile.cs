using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ProbationPeriodManagement.GetAllProbationPeriods;

namespace HRManagementSystem.Features.ProbationPeriodManagement.Mapping
{
    public sealed class GetAllProbationPeriodsProfile : Profile
    {
        public GetAllProbationPeriodsProfile()
        {
            CreateMap<ProbationPeriod, ViewProbationPeriodDto>()
          .ForMember(d => d.Id,
              o => o.MapFrom(s => s.Id))
          .ForMember(d => d.StartDate,
              o => o.MapFrom(s => s.StartDate))
          .ForMember(d => d.EndDate,
              o => o.MapFrom(s => s.EndDate))
          .ForMember(d => d.DurationInDays,
              o => o.MapFrom(s => s.DurationInDays))
          .ForMember(d => d.IsApproved,
              o => o.MapFrom(s => s.IsApproved))
          .ForMember(d => d.ApprovalDate,
              o => o.MapFrom(s => s.ApprovalDate))
          .ForMember(d => d.Status,
              o => o.MapFrom(s => s.Status));

            CreateMap<ViewProbationPeriodDto, ViewProbationPeriodViewModel>().ReverseMap();
        }
    }
}

