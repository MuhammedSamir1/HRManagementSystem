using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.AddProbationPeriod.Commands
{
    public sealed record AddProbationPeriodCommand(DateTime StartDate, DateTime EndDate, int DurationInDays,
        bool IsApproved, DateTime? ApprovalDate, ProbationPeriodStatus Status)
        : IRequest<RequestResult<CreatedIdDto>>;


    public class AddProbationPeriodCommandHandler : RequestHandlerBase<AddProbationPeriodCommand, RequestResult<CreatedIdDto>, ProbationPeriod, int>
    {
        public AddProbationPeriodCommandHandler(RequestHandlerBaseParameters<ProbationPeriod, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddProbationPeriodCommand request, CancellationToken ct)
        {
            var probationPeriod = _mapper.Map<AddProbationPeriodCommand, ProbationPeriod>(request);

            var isAdded = await _generalRepo.AddAsync(probationPeriod, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Probation Period wasn't added successfully!", ErrorCode.InternalServerError);

            var mapped = _mapper.Map<CreatedIdDto>(probationPeriod);
            return RequestResult<CreatedIdDto>.Success(mapped, "Probation Period added successfully!");
        }
    }
}

