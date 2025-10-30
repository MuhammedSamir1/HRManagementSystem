using HRManagementSystem.Features.CountryManagement.DeleteCountry;
using HRManagementSystem.Features.CountryManagement.DeleteCountry.Commands;

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
