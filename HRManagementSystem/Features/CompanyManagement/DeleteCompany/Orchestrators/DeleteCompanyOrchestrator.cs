namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Orchestrators;

public record DeleteCompanyOrchestrator(Guid companyId) : IRequest<RequestResult<bool>>;

