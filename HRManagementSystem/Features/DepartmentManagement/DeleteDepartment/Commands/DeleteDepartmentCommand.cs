namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Commands;
public record DeleteDepartmentCommand(int departmentId) : IRequest<RequestResult<bool>>;


