using HRManagementSystem.Common.Views.Response;
using MediatR;

namespace HRManagementSystem.Features.OrganizationManagement.AddOrginzationCommand.Queries
{
    public record IsOrganizationExistQuery(string organizationName) : IRequest<ResponseDto<bool>>;
}
