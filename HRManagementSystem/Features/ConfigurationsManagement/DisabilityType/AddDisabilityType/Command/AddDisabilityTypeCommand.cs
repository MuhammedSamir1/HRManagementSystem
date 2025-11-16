using HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.AddDisabilityType.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.AddDisabilityType.Command
{
    public sealed record AddDisabilityTypeCommand(string Code, string Name, string? Description = null) : IRequest<RequestResult<ViewDisabilityTypeDto>>;

    // Commands/AddDisabilityType/AddDisabilityTypeCommandHandler.cs
    public sealed class AddDisabilityTypeCommandHandler
        : RequestHandlerBase<AddDisabilityTypeCommand, RequestResult<ViewDisabilityTypeDto>, Data.Models.ConfigurationsModels.DisabilityType, Guid>
    {
        public AddDisabilityTypeCommandHandler(
            RequestHandlerBaseParameters<Data.Models.ConfigurationsModels.DisabilityType, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewDisabilityTypeDto>> Handle(
            AddDisabilityTypeCommand request, CancellationToken ct)
        {
            // Check if disability type with same code already exists
            var typeExistsResult = await _mediator.Send(
                new IsDisabilityTypeExistWithSameCodeOrNameQuery(request.Name, request.Code), ct);

            if (typeExistsResult.isSuccess)
                return RequestResult<ViewDisabilityTypeDto>.Failure(
                   "The Disability with is already exist with Same Code or Same Name", ErrorCode.DuplicateRecord);



            // Create new disability type
            var disabilityType = _mapper.Map<Data.Models.ConfigurationsModels.DisabilityType>(request);

            await _generalRepo.AddAsync(disabilityType, ct);

            var disabilityTypeDto = _mapper.Map<ViewDisabilityTypeDto>(disabilityType);
            return RequestResult<ViewDisabilityTypeDto>.Success(disabilityTypeDto);
        }
    }
}

