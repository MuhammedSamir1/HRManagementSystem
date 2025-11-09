namespace HRManagementSystem.Features.ShiftManagement.UpdateShift.Commands
{
    public sealed record UpdateShiftCommand(int Id, string Name, TimeSpan StartTime, TimeSpan EndTime)
        : IRequest<RequestResult<bool>>;

    public class UpdateShiftCommandHandler : RequestHandlerBase<UpdateShiftCommand, RequestResult<bool>, Shift, int>
    {
        public UpdateShiftCommandHandler(RequestHandlerBaseParameters<Shift, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(UpdateShiftCommand request, CancellationToken ct)
        {
            var nameExists = await _generalRepo.ExistsByNameAsync<Shift>(request.Name);
            if (nameExists)
                return RequestResult<bool>.Failure("Shift Name already exists.", ErrorCode.Conflict);

            var shift = _mapper.Map<UpdateShiftCommand, Shift>(request);
            var isUpdated = await _generalRepo.UpdatePartialAsync(shift, null, ct);

            if (!isUpdated) return RequestResult<bool>.Failure("Shift wasn't Updated successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isUpdated, "Shift Updated successfully!");
        }

    }
}

