using HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.AddDisabilityType;

namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.GetById.Queries
{
    public sealed record GetDisabilityTypeByIdQuery(Guid Id) : IRequest<RequestResult<ViewDisabilityTypeDto>>;

    // Queries/GetDisabilityTypeByIdQueryHandler.cs
    public sealed class GetDisabilityTypeByIdQueryHandler
        : RequestHandlerBase<GetDisabilityTypeByIdQuery, RequestResult<ViewDisabilityTypeDto>,
          Data.Models.ConfigurationsModels.DisabilityType, Guid>
    {
        public GetDisabilityTypeByIdQueryHandler(
            RequestHandlerBaseParameters<Data.Models.ConfigurationsModels.DisabilityType, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewDisabilityTypeDto>> Handle(
            GetDisabilityTypeByIdQuery request, CancellationToken ct)
        {
            // Get disability type by ID, excluding deleted records
            var disabilityType = await _generalRepo.GetByIdAsync(request.Id);

            if (disabilityType == null)
            {
                return RequestResult<ViewDisabilityTypeDto>.Failure(
                    "Disability type not found with this id", ErrorCode.NotFound);
            }

            var disabilityTypeDto = _mapper.Map<ViewDisabilityTypeDto>(disabilityType);

            return RequestResult<ViewDisabilityTypeDto>.Success(
                disabilityTypeDto,
                "Disability type retrieved successfully");
        }
    }
}

