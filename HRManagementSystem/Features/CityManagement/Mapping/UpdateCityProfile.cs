using AutoMapper;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.CityManagement.UpdateCity.Commands;
using HRManagementSystem.Features.CityManagement.UpdateCity.ViewModels;

namespace HRManagementSystem.Features.CityManagement.UpdateCity
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
