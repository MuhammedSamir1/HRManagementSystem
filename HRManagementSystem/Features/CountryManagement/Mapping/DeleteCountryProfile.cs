using HRManagementSystem.Features.CountryManagement.DeleteCountry.Commands;
using HRManagementSystem.Features.CountryManagement.ViewModels.DeleteCountry;

namespace HRManagementSystem.Features.CountryManagement.Mapping
{
    public sealed class DeleteCountryProfile : Profile
    {
        public DeleteCountryProfile()
        {

            CreateMap<DeleteCountryViewModel, DeleteCountryCommand>();


        }
    }
}
