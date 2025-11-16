using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.DeletePenalty.Commands
{
    public sealed record DeletePenaltyCommand(Guid Id) : IRequest<RequestResult<bool>>;

    public class DeletePenaltyCommandHandler : RequestHandlerBase<DeletePenaltyCommand, RequestResult<bool>, Penalty, Guid>
    {
        public DeletePenaltyCommandHandler(RequestHandlerBaseParameters<Penalty, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeletePenaltyCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted)
                return RequestResult<bool>.Failure("Penalty not found or wasn't deleted successfully!", ErrorCode.NotFound);

            return RequestResult<bool>.Success(true, "Penalty deleted successfully!");
        }
    }
}

