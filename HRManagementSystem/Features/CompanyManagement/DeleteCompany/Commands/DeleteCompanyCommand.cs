namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Commands
{
    public record DeleteCompanyCommand(int companyId) : IRequest<RequestResult<bool>>;

    public sealed class DeleteCompanyCommandHandler : RequestHandlerBase<DeleteCompanyCommand,
    RequestResult<bool>, Company, int>
    {
        public DeleteCompanyCommandHandler(RequestHandlerBaseParameters<Company, int> parameters) : base(parameters)
        { }

        public override async Task<RequestResult<bool>> Handle(DeleteCompanyCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.companyId, ct);

            if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.OrganizationNotFound);
            return RequestResult<bool>.Success(isDeleted);
        }
    }
}
