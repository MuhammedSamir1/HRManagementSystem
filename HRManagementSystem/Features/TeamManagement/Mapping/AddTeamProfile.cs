using HRManagementSystem.Features.Common.Dtos;
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


            CreateMap<Team, CreatedIdDto>()
                .ForMember(d => d.Id,
                    o => o.MapFrom(s => s.Id));

            CreateMap<AddTeamCommand, AddTeamViewModel>().ReverseMap();
        }
    }
}
