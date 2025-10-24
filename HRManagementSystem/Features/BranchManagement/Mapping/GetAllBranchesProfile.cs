using AutoMapper;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.BranchManagement.GetAllBranches;
using HRManagementSystem.Features.BranchManagement.GetBranchById;

namespace HRManagementSystem.Features.BranchManagement.Mapping
{
    public sealed class GetAllBranchesProfile : Profile
    {
        public GetAllBranchesProfile()
        {
            CreateMap<Branch, ViewBranchDto>()
        .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
        .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
        .ForMember(d => d.Code, o => o.MapFrom(s => s.Code))
        .ForMember(d => d.Address, o => o.MapFrom(s => s.Address));

            CreateMap<ViewBranchDto, ViewBranchViewModel>().ReverseMap();
        }
    }
}
