namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Commands
{
    public sealed record DeleteOrganizationCommand(int Id) : IRequest<RequestResult<bool>>;

    public sealed class DeleteOrganizationCommandHandler : RequestHandlerBase<DeleteOrganizationCommand,
        RequestResult<bool>, Organization, int>
    {
        public DeleteOrganizationCommandHandler(RequestHandlerBaseParameters<Organization, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteOrganizationCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);
            if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.OrganizationNotFound);
            return RequestResult<bool>.Success(isDeleted);
        }
    }
}
