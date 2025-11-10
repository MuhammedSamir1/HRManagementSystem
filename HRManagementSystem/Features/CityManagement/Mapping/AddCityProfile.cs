using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.CityManagement.AddCity;
using HRManagementSystem.Features.CityManagement.AddCity.Commands;

namespace HRManagementSystem.Features.CityManagement.Mapping
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
