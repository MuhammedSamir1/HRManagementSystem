using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.UpdateProbationPeriod;
using HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.UpdateProbationPeriod.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.Mapping
{
    public sealed class UpdateProbationPeriodProfile : Profile
    {
        public UpdateProbationPeriodProfile()
        {
            CreateMap<UpdateProbationPeriodCommand, ProbationPeriod>()
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


            CreateMap<UpdateProbationPeriodCommand, UpdateProbationPeriodViewModel>().ReverseMap();
        }
    }
}

