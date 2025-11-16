namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Commands;
public record DeleteDepartmentCommand(Guid departmentId) : IRequest<RequestResult<bool>>;



