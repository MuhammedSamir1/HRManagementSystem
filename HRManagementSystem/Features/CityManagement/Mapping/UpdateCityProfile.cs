using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.CityManagement.UpdateCity;
using HRManagementSystem.Features.CityManagement.UpdateCity.Command;

namespace HRManagementSystem.Features.CityManagement.Mapping
{
    public class UpdateCityProfile : Profile
    {
        public UpdateCityProfile()
        {
            CreateMap<UpdateCityCommand, City>()
             .ForMember(d => d.Id,
                 o => o.MapFrom(s => s.Id))
             .ForMember(d => d.Name,
                 o => o.MapFrom(s => s.Name.Trim()))
             .ForMember(d => d.StateId,
             o => o.MapFrom(s => s.StateId));


            CreateMap<UpdateCityCommand, UpdateCityViewModel>();
        }
    }
}
