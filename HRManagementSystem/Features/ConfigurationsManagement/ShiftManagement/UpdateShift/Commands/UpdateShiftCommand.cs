using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.UpdateShift.Commands
{
    public sealed record UpdateShiftCommand(Guid Id, string Name, TimeSpan StartTime, TimeSpan EndTime)
        : IRequest<RequestResult<bool>>;

    public class UpdateShiftCommandHandler : RequestHandlerBase<UpdateShiftCommand, RequestResult<bool>, Shift, Guid>
    {
        public UpdateShiftCommandHandler(RequestHandlerBaseParameters<Shift, Guid> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(UpdateShiftCommand request, CancellationToken ct)
        {
            // Check if shift exists
            var isExist = await _generalRepo.IsExistAsync(request.Id, ct);
            if (!isExist) return RequestResult<bool>.Failure("Shift not found.", ErrorCode.ShiftNotFound);

            // Check if name already exists for a different shift
            var existingShift = await _generalRepo.Get(x => x.Name.ToLower() == request.Name.ToLower() && x.Id != request.Id, ct)
                .FirstOrDefaultAsync(ct);

            if (existingShift is not null)
                return RequestResult<bool>.Failure("Shift Name already exists.", ErrorCode.Conflict);

            var shift = _mapper.Map<UpdateShiftCommand, Shift>(request);
            var isUpdated = await _generalRepo.UpdatePartialAsync(shift, null, ct);

            if (!isUpdated) return RequestResult<bool>.Failure("Shift wasn't Updated successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isUpdated, "Shift Updated successfully!");
        }

    }
}


