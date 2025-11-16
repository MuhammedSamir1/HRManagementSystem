using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.AddPenalty.Commands
{
    public sealed record AddPenaltyCommand(
        string Title,
        string? Description,
        decimal Amount,
        DateTime PenaltyDate,
        string? Reason,
        PenaltyStatus Status)
        : IRequest<RequestResult<Guid>>;

    public class AddPenaltyCommandHandler : RequestHandlerBase<AddPenaltyCommand, RequestResult<Guid>, Penalty, Guid>
    {
        public AddPenaltyCommandHandler(RequestHandlerBaseParameters<Penalty, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<Guid>> Handle(AddPenaltyCommand request, CancellationToken ct)
        {
            var penalty = _mapper.Map<Penalty>(request);

            var isAdded = await _generalRepo.AddAsync(penalty, ct);

            if (!isAdded)
                return RequestResult<Guid>.Failure("Penalty wasn't added successfully!", ErrorCode.InternalServerError);

            return RequestResult<Guid>.Success(penalty.Id, "Penalty added successfully!");
        }
    }
}

