namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;
public record DeleteCompanyCommand(Guid companyId) : IRequest<RequestResult<bool>>;

