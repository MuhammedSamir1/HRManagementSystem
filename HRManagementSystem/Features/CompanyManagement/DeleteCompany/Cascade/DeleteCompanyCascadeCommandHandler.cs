using HRManagementSystem.Features.Common.DeleteEntityCascade.Handler;

namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Cascade;

public sealed class DeleteCompanyCascadeCommandHandler
        : DeleteEntityCascadeCommandHandler<Company, int>
{
    public DeleteCompanyCascadeCommandHandler(
        RequestHandlerBaseParameters<Company, int> parameters
    ) : base(parameters)
    {
    }
}
