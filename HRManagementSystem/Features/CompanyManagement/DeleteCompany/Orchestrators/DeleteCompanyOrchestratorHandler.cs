using HRManagementSystem.Features.Common.IsAnyChildAssignedGeneric;
using HRManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;

namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Orchestrators;

public sealed class DeleteCompanyOrchestratorHandler : RequestHandlerBase<DeleteCompanyOrchestrator,
RequestResult<bool>, Company, int>
{
    public DeleteCompanyOrchestratorHandler(RequestHandlerBaseParameters<Company, int> parameters) : base(parameters)
    { }

    public override async Task<RequestResult<bool>> Handle(DeleteCompanyOrchestrator request, CancellationToken ct)
    {
        // Check if any Branches assigned to this Company 

        var hasBranches = await _mediator.Send(new IsAnyChildAssignedQuery<Company, Branch, int>(request.companyId), ct);
        if (hasBranches.data)
        {
            return RequestResult<bool>.Failure("Cannot delete company. There are branches assigned to this company.");
        }

        var isDeleted = await _mediator.Send(new DeleteCompanyCommand(request.companyId));

        if (!isDeleted.isSuccess) return RequestResult<bool>.Failure(isDeleted.message, isDeleted.errorCode);
        return RequestResult<bool>.Success(isDeleted.isSuccess, isDeleted.message);
    }
}