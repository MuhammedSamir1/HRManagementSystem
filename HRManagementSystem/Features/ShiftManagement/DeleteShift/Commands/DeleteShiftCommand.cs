using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ShiftManagement.DeleteShift.Commands
{
    public sealed record DeleteShiftCommand(int Id) : IRequest<RequestResult<bool>>;


    public sealed class DeleteShiftCommandHandler : RequestHandlerBase<DeleteShiftCommand,
        RequestResult<bool>, Shift, int>
    {
        public DeleteShiftCommandHandler(RequestHandlerBaseParameters<Shift, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteShiftCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, cancellationToken);
            if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.ShiftNotFound);
            return RequestResult<bool>.Success(isDeleted);
        }
    }
}

