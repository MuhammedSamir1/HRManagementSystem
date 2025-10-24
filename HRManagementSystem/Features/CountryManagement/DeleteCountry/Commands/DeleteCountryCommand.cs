using HRManagementSystem.Common.Views.Response;
using MediatR;

namespace HRManagementSystem.Features.CountryManagement.DeleteCountry.Commands
{
    public sealed record DeleteCountryCommand(int Id)
     : IRequest<ResponseViewModel<bool>>;
}
