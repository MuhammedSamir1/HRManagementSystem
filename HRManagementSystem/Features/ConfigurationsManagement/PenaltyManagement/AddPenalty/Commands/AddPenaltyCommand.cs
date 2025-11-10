using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.AddPenalty.Commands
{
    public sealed record AddPenaltyCommand(
        string Title,
        string? Description,
        decimal Amount,
        DateTime PenaltyDate,
        string? Reason,
        PenaltyStatus Status,
        int? EmployeeId)
        : IRequest<RequestResult<int>>;

    public class AddPenaltyCommandHandler : RequestHandlerBase<AddPenaltyCommand, RequestResult<int>, Penalty, int>
    {
        public AddPenaltyCommandHandler(RequestHandlerBaseParameters<Penalty, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<int>> Handle(AddPenaltyCommand request, CancellationToken ct)
        {
            var penalty = _mapper.Map<Penalty>(request);

            var isAdded = await _generalRepo.AddAsync(penalty, ct);

            if (!isAdded)
                return RequestResult<int>.Failure("Penalty wasn't added successfully!", ErrorCode.InternalServerError);

            return RequestResult<int>.Success(penalty.Id, "Penalty added successfully!");
        }
    }
}
