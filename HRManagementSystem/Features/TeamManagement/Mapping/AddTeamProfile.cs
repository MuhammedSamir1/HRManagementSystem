using AutoMapper;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.TeamManagement.AddTeam;
using HRManagementSystem.Features.TeamManagement.AddTeam.Commands;

namespace HRManagementSystem.Features.TeamManagement.Mapping
{
    public sealed class AddTeamProfile : Profile
    {
        public AddTeamProfile()
        {
            CreateMap<AddTeamCommand, Team>()
             .ForMember(d => d.Name,
                 o => o.MapFrom(s => s.Name.Trim()))
             .ForMember(d => d.Code,
             o => o.MapFrom(s => s.Code.Trim()))
             .ForMember(d => d.Description,
             o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Description) ? null : s.Description.Trim()));


            CreateMap<AddTeamCommand, AddTeamViewModel>().ReverseMap();
        }
    }
}
