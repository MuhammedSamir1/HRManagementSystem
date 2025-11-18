using HRManagementSystem.Data.Models.Scopes;

namespace HRManagementSystem.Features.ScopeManagement.DeleteScope.Commands
{
    public sealed record DeleteScopeCommand(Guid Id) : IRequest<RequestResult<bool>>;

    public sealed class DeleteScopeCommandHandler : RequestHandlerBase<DeleteScopeCommand, RequestResult<bool>, Scope, Guid>
    {
        public DeleteScopeCommandHandler(RequestHandlerBaseParameters<Scope, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(DeleteScopeCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted)
            {
                return RequestResult<bool>.Failure("Scope not found or wasn't deleted successfully!", ErrorCode.NotFound);
            }

            return RequestResult<bool>.Success(true, "Scope deleted successfully!");
        }
    }
}

