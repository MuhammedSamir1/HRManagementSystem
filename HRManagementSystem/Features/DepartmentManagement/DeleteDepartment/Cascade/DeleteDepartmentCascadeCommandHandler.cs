using HRManagementSystem.Features.Common.DeleteCascadeGeneric;

namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Cascade;

public sealed class DeleteDepartmentCascadeCommandHandler
        : DeleteEntityCascadeCommandHandler<Department, int>
{
    public DeleteDepartmentCascadeCommandHandler(
        RequestHandlerBaseParameters<Department, int> parameters
    ) : base(parameters)
    {
    }
}
