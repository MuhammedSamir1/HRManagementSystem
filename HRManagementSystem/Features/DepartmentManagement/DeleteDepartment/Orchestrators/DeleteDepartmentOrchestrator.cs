namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Orchestrators;

public record DeleteDepartmentOrchestrator(Guid departmentId) : IRequest<RequestResult<bool>>;


