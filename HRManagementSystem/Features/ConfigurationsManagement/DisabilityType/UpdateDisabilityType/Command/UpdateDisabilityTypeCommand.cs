using HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.AddDisabilityType;

namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.UpdateDisabilityType.Command
{
    public sealed record UpdateDisabilityTypeCommand(int Id, string Code, string Name, string? Description = null) : IRequest<RequestResult<ViewDisabilityTypeDto>>;

    // Commands/UpdateDisabilityType/UpdateDisabilityTypeCommandHandler.cs
    public sealed class UpdateDisabilityTypeCommandHandler
        : RequestHandlerBase<UpdateDisabilityTypeCommand, RequestResult<ViewDisabilityTypeDto>,
          HRManagementSystem.Data.Models.ConfigurationOfSys.DisabilityType, int>
    {
        public UpdateDisabilityTypeCommandHandler(
            RequestHandlerBaseParameters<HRManagementSystem.Data.Models.ConfigurationOfSys.DisabilityType, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewDisabilityTypeDto>> Handle(
            UpdateDisabilityTypeCommand request, CancellationToken ct)
        {
            // Check if disability type exists
            var existingDisabilityType = await _generalRepo.IsExistAsync(request.Id, ct);
            if (!existingDisabilityType)
            {
                return RequestResult<ViewDisabilityTypeDto>.Failure(
                    "Disability type not found with this id", ErrorCode.NotFound);
            }


            // Update disability type
            var updatedDis = _mapper.Map<Data.Models.ConfigurationOfSys.DisabilityType>(request);


            await _generalRepo.UpdateAsync(updatedDis, ct);

            var disabilityTypeDto = _mapper.Map<ViewDisabilityTypeDto>(updatedDis);
            return RequestResult<ViewDisabilityTypeDto>.Success(disabilityTypeDto, "Disability type updated successfully");
        }
    }
}
