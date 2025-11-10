using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;
using HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.AddProbationPeriod;
using HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.AddProbationPeriod.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.Mapping
{
    public sealed class AddProbationPeriodProfile : Profile
    {
        public AddProbationPeriodProfile()
        {
            CreateMap<AddProbationPeriodCommand, ProbationPeriod>()
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


            CreateMap<ProbationPeriod, CreatedIdDto>()
                .ForMember(d => d.Id,
                    o => o.MapFrom(s => s.Id));

            CreateMap<AddProbationPeriodCommand, AddProbationPeriodViewModel>().ReverseMap();
        }
    }
}

