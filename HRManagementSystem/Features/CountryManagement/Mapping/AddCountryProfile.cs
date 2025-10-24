using AutoMapper;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.CountryManagement.AddCountry.Commands;
using HRManagementSystem.Features.CountryManagement.ViewModels.AddCountry;

namespace HRManagementSystem.Features.CountryManagement.Mapping
{
    public sealed class AddCountryProfile : Profile
    {
        public AddCountryProfile()
        {
           
            CreateMap<AddCountryViewModel, AddCountryCommand>();

      
            CreateMap<AddCountryCommand, Country>();
        }
    }
}
