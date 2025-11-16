namespace HRManagementSystem.Features.CountryManagement.DeleteCountry.Commands
{
    public sealed record DeleteCountryCommand(Guid Id)
     : IRequest<RequestResult<bool>>;
}

