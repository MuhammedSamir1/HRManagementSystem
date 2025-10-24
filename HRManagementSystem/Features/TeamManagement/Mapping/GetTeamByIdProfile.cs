using AutoMapper;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.TeamManagement.GetTeamById;

namespace HRManagementSystem.Features.TeamManagement.Mapping
{
    public sealed class GetTeamByIdProfile : Profile
    {
        public GetTeamByIdProfile()
        {
            CreateMap<Team, ViewTeamByIdDto>()
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

            CreateMap<ViewTeamByIdDto, ViewTeamByIdViewModel>().ReverseMap();
        }
    }
}
