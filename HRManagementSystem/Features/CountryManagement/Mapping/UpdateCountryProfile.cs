using AutoMapper;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.CountryManagement.UpdateCountry.Commands;
using HRManagementSystem.Features.CountryManagement.ViewModels.UpdateCountry;

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
