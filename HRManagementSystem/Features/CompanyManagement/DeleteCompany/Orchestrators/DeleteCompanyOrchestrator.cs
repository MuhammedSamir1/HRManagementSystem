namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Orchestrator;

public record DeleteCompanyOrchestrator(int companyId) : IRequest<RequestResult<bool>>;
