using HRManagementSystem.Features.Common.DeleteEntityCascade.Handler;

namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Cascade;

public sealed class DeleteDepartmentCascadeCommandHandler
        : DeleteEntityCascadeCommandHandler<Department, Guid>
{
    public DeleteDepartmentCascadeCommandHandler(
        RequestHandlerBaseParameters<Department, Guid> parameters
    ) : base(parameters)
    {
    }
}

