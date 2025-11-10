using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.UpdatePenalty.Commands
{
    public sealed record UpdatePenaltyCommand(
        int Id,
        string Title,
        string? Description,
        decimal Amount,
        DateTime PenaltyDate,
        string? Reason,
        PenaltyStatus Status,
        int? EmployeeId)
        : IRequest<RequestResult<string>>;

    public class UpdatePenaltyCommandHandler : RequestHandlerBase<UpdatePenaltyCommand, RequestResult<string>, Penalty, int>
    {
        public UpdatePenaltyCommandHandler(RequestHandlerBaseParameters<Penalty, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<string>> Handle(UpdatePenaltyCommand request, CancellationToken ct)
        {
            var penalty = await _generalRepo.GetByIdAsync(request.Id, ct);

            if (penalty == null)
                return RequestResult<string>.Failure("Penalty not found.", ErrorCode.NotFound);

            _mapper.Map(request, penalty);

            var isUpdated = await _generalRepo.UpdateAsync(penalty, ct);

            if (!isUpdated)
                return RequestResult<string>.Failure("Penalty wasn't updated successfully!", ErrorCode.InternalServerError);

            return RequestResult<string>.Success("Penalty updated successfully!");
        }
    }
}
