using HRManagementSystem.Features.BranchManagement.AddBranch;
using HRManagementSystem.Features.BranchManagement.AddBranch.Commands;

namespace HRManagementSystem.Features.BranchManagement.Mapping
{
    public sealed class AddBranchProfile : Profile
    {
        public AddBranchProfile()
        {
            CreateMap<AddBranchCommand, Branch>()
          .ForMember(d => d.Name,
              o => o.MapFrom(s => s.Name.Trim()))
          .ForMember(d => d.Description,
              o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Description) ? null : s.Description.Trim()))

          .ForMember(d => d.Address,
              o => o.MapFrom(s => s.AddressDto))
          .ForMember(d => d.AddressId, o => o.Ignore());


            CreateMap<AddBranchCommand, AddBranchViewModel>().ReverseMap();
        }
    }
}
