using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.ViewModels;
using HRManagementSystem.Features.StateManagement.AddState.Command;
using HRManagementSystem.Features.StateManagement.UpdateState.Command;

namespace HRManagementSystem.Features.Common.AddressManagement.StateCommon
{
    public sealed class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, ViewStateDto>().ReverseMap();

            CreateMap<ViewStateDto, ViewStateViewModel>();

            // Mapping from AddStateCommand to State
            CreateMap<AddStateCommand, State>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.Cities, opt => opt.Ignore())
                .ForMember(dest => dest.Country, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateStateCommand, State>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId))
             .ForMember(dest => dest.Cities, opt => opt.Ignore())
             .ForMember(dest => dest.Country, opt => opt.Ignore());
        }
    }
}
