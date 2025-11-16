using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.DeleteProbationPeriod.Commands
{
    public sealed record DeleteProbationPeriodCommand(Guid Id) : IRequest<RequestResult<bool>>;


    public sealed class DeleteProbationPeriodCommandHandler : RequestHandlerBase<DeleteProbationPeriodCommand,
        RequestResult<bool>, ProbationPeriod, Guid>
    {
        public DeleteProbationPeriodCommandHandler(RequestHandlerBaseParameters<ProbationPeriod, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteProbationPeriodCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, cancellationToken);
            if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.ProbationPeriodNotFound);
            return RequestResult<bool>.Success(isDeleted);
        }
    }
}


