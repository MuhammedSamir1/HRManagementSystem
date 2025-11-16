using HRManagementSystem.Features.Common.DeleteEntityCascade.Handler;

namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Cascade;

public sealed class DeleteCompanyCascadeCommandHandler
        : DeleteEntityCascadeCommandHandler<Company, Guid>
{
    public DeleteCompanyCascadeCommandHandler(
        RequestHandlerBaseParameters<Company, Guid> parameters
    ) : base(parameters)
    {
    }
}

