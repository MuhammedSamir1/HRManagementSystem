namespace HRManagementSystem.Features.ProbationPeriodManagement.UpdateProbationPeriod.Commands
{
    public sealed record UpdateProbationPeriodCommand(int Id, DateTime StartDate, DateTime EndDate, 
        int DurationInDays, bool IsApproved, DateTime? ApprovalDate, ProbationPeriodStatus Status)
        : IRequest<RequestResult<bool>>;

    public class UpdateProbationPeriodCommandHandler : RequestHandlerBase<UpdateProbationPeriodCommand, RequestResult<bool>, ProbationPeriod, int>
    {
        public UpdateProbationPeriodCommandHandler(RequestHandlerBaseParameters<ProbationPeriod, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(UpdateProbationPeriodCommand request, CancellationToken ct)
        {
            // Check if probation period exists
            var isExist = await _generalRepo.IsExistAsync(request.Id, ct);
            if (!isExist) return RequestResult<bool>.Failure("Probation Period not found.", ErrorCode.ProbationPeriodNotFound);

            var probationPeriod = _mapper.Map<UpdateProbationPeriodCommand, ProbationPeriod>(request);
            var isUpdated = await _generalRepo.UpdatePartialAsync(probationPeriod, null, ct);

            if (!isUpdated) return RequestResult<bool>.Failure("Probation Period wasn't Updated successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isUpdated, "Probation Period Updated successfully!");
        }

    }
}

