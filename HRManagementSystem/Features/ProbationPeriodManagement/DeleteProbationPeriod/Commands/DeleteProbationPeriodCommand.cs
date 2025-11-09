namespace HRManagementSystem.Features.ProbationPeriodManagement.DeleteProbationPeriod.Commands
{
    public sealed record DeleteProbationPeriodCommand(int Id) : IRequest<RequestResult<bool>>;


    public sealed class DeleteProbationPeriodCommandHandler : RequestHandlerBase<DeleteProbationPeriodCommand,
        RequestResult<bool>, ProbationPeriod, int>
    {
        public DeleteProbationPeriodCommandHandler(RequestHandlerBaseParameters<ProbationPeriod, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteProbationPeriodCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, cancellationToken);
            if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.ProbationPeriodNotFound);
            return RequestResult<bool>.Success(isDeleted);
        }
    }
}

