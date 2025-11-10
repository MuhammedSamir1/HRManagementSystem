namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Orchestrators;

public record DeleteDepartmentOrchestrator(int departmentId) : IRequest<RequestResult<bool>>;

