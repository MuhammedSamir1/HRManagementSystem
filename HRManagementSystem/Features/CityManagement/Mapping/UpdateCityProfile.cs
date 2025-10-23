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
            CreateMap<UpdateCityViewModel, City>();
            CreateMap<City, UpdateCityViewModel>();
            CreateMap<UpdateCityViewModel, UpdateCityCommand>()
                .ConstructUsing(vm => new UpdateCityCommand(vm.Id, vm.Name, vm.StateId));
        }
    }
}
