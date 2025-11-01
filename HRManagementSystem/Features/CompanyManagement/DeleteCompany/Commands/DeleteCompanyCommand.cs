namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;
public record DeleteCompanyCommand(int companyId) : IRequest<RequestResult<bool>>;
