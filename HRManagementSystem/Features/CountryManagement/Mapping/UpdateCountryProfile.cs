using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.CountryManagement.UpdateCountry;
using HRManagementSystem.Features.CountryManagement.UpdateCountry.Commands;

namespace HRManagementSystem.Features.CountryManagement.Mapping
{
    public sealed class UpdateCountryProfile : Profile
    {
        public UpdateCountryProfile()
        {

            CreateMap<UpdateCountryViewModel, UpdateCountryCommand>();


            CreateMap<UpdateCountryCommand, Country>();
        }
    }
}
