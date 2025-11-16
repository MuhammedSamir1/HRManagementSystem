namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;

public sealed class DeleteCompanyCommandHandler : RequestHandlerBase<DeleteCompanyCommand,
RequestResult<bool>, Company, Guid>
{
    public DeleteCompanyCommandHandler(RequestHandlerBaseParameters<Company, Guid> parameters) : base(parameters)
    { }

    public override async Task<RequestResult<bool>> Handle(DeleteCompanyCommand request, CancellationToken ct)
    {
        var isDeleted = await _generalRepo.SoftDeleteAsync(request.companyId, ct);

        if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.OrganizationNotFound);
        return RequestResult<bool>.Success(isDeleted);
    }
}
