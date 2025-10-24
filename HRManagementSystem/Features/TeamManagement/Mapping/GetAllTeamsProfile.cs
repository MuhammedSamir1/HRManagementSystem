using AutoMapper;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.TeamManagement.GetAllTeams;

namespace HRManagementSystem.Features.TeamManagement.Mapping
{
    public sealed class GetAllTeamsProfile : Profile
    {
        public GetAllTeamsProfile()
        {
            CreateMap<Team, ViewTeamDto>()
          .ForMember(d => d.Id,
              o => o.MapFrom(s => s.Id))
          .ForMember(d => d.Name,
              o => o.MapFrom(s => s.Name.Trim()))
          .ForMember(d => d.Code,
          o => o.MapFrom(s => s.Code.Trim()))
          .ForMember(d => d.Description,
          o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Description) ? null : s.Description.Trim()))
          .ForMember(d => d.DepartmentId,
              o => o.MapFrom(s => s.DepartmentId));

            CreateMap<ViewTeamDto, ViewTeamViewModel>().ReverseMap();
        }
    }
}
