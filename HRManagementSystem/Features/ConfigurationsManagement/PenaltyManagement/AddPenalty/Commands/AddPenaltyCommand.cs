using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;

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
        : IRequest<RequestResult<CreatedIdDto>>;

    public class AddPenaltyCommandHandler : RequestHandlerBase<AddPenaltyCommand, RequestResult<CreatedIdDto>, Penalty, int>
    {
        public AddPenaltyCommandHandler(RequestHandlerBaseParameters<Penalty, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddPenaltyCommand request, CancellationToken ct)
        {
            var penalty = _mapper.Map<AddPenaltyCommand, Penalty>(request);

            var isAdded = await _generalRepo.AddAsync(penalty, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Penalty wasn't added successfully!", ErrorCode.InternalServerError);

            var mapped = _mapper.Map<CreatedIdDto>(penalty);
            return RequestResult<CreatedIdDto>.Success(mapped, "Penalty added successfully!");
        }
    }
}

