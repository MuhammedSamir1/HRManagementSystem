using HRManagementSystem.Features.BranchManagement.GetBranchById;

namespace HRManagementSystem.Features.BranchManagement.Mapping
{
    public sealed class GetBranchByIdProfile : Profile
    {
        public GetBranchByIdProfile()
        {
            CreateMap<Branch, ViewBranchByIdDto>()
          .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
          .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
          .ForMember(d => d.Code, o => o.MapFrom(s => s.Code))
          .ForMember(d => d.Address, o => o.MapFrom(s => s.Address));

            CreateMap<ViewBranchByIdDto, ViewBranchByIdViewModel>().ReverseMap();
        }
    }
}
