using HRManagementSystem.Features.Common.DeleteCascadeGeneric;

namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Cascade;

public sealed class DeleteCompanyCascadeCommandHandler
        : DeleteEntityCascadeCommandHandler<Company, int>
{
    public DeleteCompanyCascadeCommandHandler(
        RequestHandlerBaseParameters<Company, int> parameters,
        IServiceProvider sp
    ) : base(parameters, sp)
    {
    }
}
