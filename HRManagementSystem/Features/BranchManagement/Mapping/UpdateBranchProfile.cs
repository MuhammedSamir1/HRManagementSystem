using HRManagementSystem.Features.BranchManagement.UpdateBranch;
using HRManagementSystem.Features.BranchManagement.UpdateBranch.Commands;

namespace HRManagementSystem.Features.BranchManagement.Mapping
{
    public class UpdateBranchProfile : Profile
    {
        public UpdateBranchProfile()
        {
            CreateMap<UpdateBranchCommand, Branch>()
          .ForMember(d => d.Id,
              o => o.MapFrom(s => s.Id))
          .ForMember(d => d.Name,
              o => o.MapFrom(s => s.Name.Trim()))
          .ForMember(d => d.Description,
              o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Description) ? null : s.Description.Trim()))
          .ForMember(d => d.Code,
              o => o.MapFrom(s => s.Code.Trim()))
          .ForMember(d => d.CompanyId,
              o => o.Ignore())

          .ForMember(d => d.Address,
              o => o.MapFrom(s => s.AddressDto))
          .ForMember(d => d.AddressId, o => o.Ignore());


            CreateMap<UpdateBranchCommand, UpdateBranchViewModel>().ReverseMap();
        }
    }
}
