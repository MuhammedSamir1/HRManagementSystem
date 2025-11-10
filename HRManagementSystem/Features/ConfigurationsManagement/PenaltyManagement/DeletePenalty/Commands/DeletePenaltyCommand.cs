using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.DeletePenalty.Commands
{
    public sealed record DeletePenaltyCommand(int Id) : IRequest<RequestResult<string>>;

    public class DeletePenaltyCommandHandler : RequestHandlerBase<DeletePenaltyCommand, RequestResult<string>, Penalty, int>
    {
        public DeletePenaltyCommandHandler(RequestHandlerBaseParameters<Penalty, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<string>> Handle(DeletePenaltyCommand request, CancellationToken ct)
        {
            var penalty = await _generalRepo.GetByIdAsync(request.Id, ct);

            if (penalty == null)
                return RequestResult<string>.Failure("Penalty not found.", ErrorCode.NotFound);

            var isDeleted = await _generalRepo.DeleteAsync(penalty, ct);

            if (!isDeleted)
                return RequestResult<string>.Failure("Penalty wasn't deleted successfully!", ErrorCode.InternalServerError);

            return RequestResult<string>.Success("Penalty deleted successfully!");
        }
    }
}
