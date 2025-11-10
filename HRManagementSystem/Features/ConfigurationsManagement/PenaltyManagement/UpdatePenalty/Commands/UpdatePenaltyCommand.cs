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
        : IRequest<RequestResult<bool>>;

    public class UpdatePenaltyCommandHandler : RequestHandlerBase<UpdatePenaltyCommand, RequestResult<bool>, Penalty, int>
    {
        public UpdatePenaltyCommandHandler(RequestHandlerBaseParameters<Penalty, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(UpdatePenaltyCommand request, CancellationToken ct)
        {
            var penalty = await _generalRepo.GetByIdWithTracking(request.Id);

            if (penalty == null || penalty.IsDeleted)
                return RequestResult<bool>.Failure("Penalty not found.", ErrorCode.NotFound);

            penalty.Title = request.Title;
            penalty.Description = request.Description;
            penalty.Amount = request.Amount;
            penalty.PenaltyDate = request.PenaltyDate;
            penalty.Reason = request.Reason;
            penalty.Status = request.Status;
            penalty.EmployeeId = request.EmployeeId;

            await _generalRepo.UpdateAsync(penalty, ct);

            return RequestResult<bool>.Success(true, "Penalty updated successfully!");
        }
    }
}
