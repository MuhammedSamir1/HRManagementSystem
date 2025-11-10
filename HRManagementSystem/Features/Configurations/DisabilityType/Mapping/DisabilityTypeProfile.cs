using HRManagementSystem.Features.Configurations.DisabilityType.AddDisabilityType;
using HRManagementSystem.Features.Configurations.DisabilityType.AddDisabilityType.Command;
using HRManagementSystem.Features.Configurations.DisabilityType.UpdateDisabilityType.Command;

namespace HRManagementSystem.Features.Configurations.DisabilityType.Mapping
{
    public class DisabilityTypeProfile : Profile
    {
        public DisabilityTypeProfile()
        {
            CreateMap<Data.Models.ConfigurationOfSys.DisabilityType, ViewDisabilityTypeDto>();
            CreateMap<ViewDisabilityTypeDto, ViewDisabilityTypeViewModel>();
            CreateMap<AddDisabilityTypeCommand, Data.Models.ConfigurationOfSys.DisabilityType>();

            CreateMap<AddDisabilityTypeCommand, Data.Models.ConfigurationOfSys.DisabilityType>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Important: Ignore Id
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Employees, opt => opt.Ignore());

            CreateMap<UpdateDisabilityTypeCommand, Data.Models.ConfigurationOfSys.DisabilityType>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
             .ForMember(dest => dest.Employees, opt => opt.Ignore())
             .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
             .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
             .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
             .ForMember(dest => dest.IsActive, opt => opt.Ignore());
        }
    }
}
