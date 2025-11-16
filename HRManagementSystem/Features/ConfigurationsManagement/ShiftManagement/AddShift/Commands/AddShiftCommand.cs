using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.AddShift.Commands
{
    public sealed record AddShiftCommand(string Name, TimeSpan StartTime, TimeSpan EndTime)
        : IRequest<RequestResult<CreatedIdDto>>;


    public class AddShiftCommandHandler : RequestHandlerBase<AddShiftCommand, RequestResult<CreatedIdDto>, Shift, Guid>
    {
        public AddShiftCommandHandler(RequestHandlerBaseParameters<Shift, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddShiftCommand request, CancellationToken ct)
        {
            var shift = _mapper.Map<AddShiftCommand, Shift>(request);

            var nameExists = await _generalRepo.ExistsByNameAsync<Shift>(request.Name);
            if (nameExists)
                return RequestResult<CreatedIdDto>.Failure("Shift Name already exists.", ErrorCode.Conflict);

            var isAdded = await _generalRepo.AddAsync(shift, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Shift wasn't added successfully!", ErrorCode.InternalServerError);

            var mapped = _mapper.Map<CreatedIdDto>(shift);
            return RequestResult<CreatedIdDto>.Success(mapped, "Shift added successfully!");
        }
    }
}


