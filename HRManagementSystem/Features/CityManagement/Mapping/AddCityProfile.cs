using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.CityManagement.AddCity.Commands;
using HRManagementSystem.Features.Common.AddressManagement.AddCity.ViewModels;

namespace HRManagementSystem.Features.CityManagement.AddCity
{
    public class AddCityProfile : Profile
    {
        public AddCityProfile()
        {
            CreateMap<AddCityViewModel, City>();
            CreateMap<City, AddCityViewModel>();
            CreateMap<AddCityViewModel, AddCityCommand>()
                .ConstructUsing(vm => new AddCityCommand(vm.Name, vm.StateId));
        }
    }
}
