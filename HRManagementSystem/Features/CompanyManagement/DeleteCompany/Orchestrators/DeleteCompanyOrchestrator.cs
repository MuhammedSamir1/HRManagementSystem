namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Orchestrators;

public record DeleteCompanyOrchestrator(int companyId) : IRequest<RequestResult<bool>>;
