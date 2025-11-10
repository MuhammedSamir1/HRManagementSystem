using HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.AddDisabilityType;

namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.GetById.Queries
{
    public sealed record GetDisabilityTypeByIdQuery(int Id) : IRequest<RequestResult<ViewDisabilityTypeDto>>;

    // Queries/GetDisabilityTypeByIdQueryHandler.cs
    public sealed class GetDisabilityTypeByIdQueryHandler
        : RequestHandlerBase<GetDisabilityTypeByIdQuery, RequestResult<ViewDisabilityTypeDto>,
          HRManagementSystem.Data.Models.ConfigurationOfSys.DisabilityType, int>
    {
        public GetDisabilityTypeByIdQueryHandler(
            RequestHandlerBaseParameters<HRManagementSystem.Data.Models.ConfigurationOfSys.DisabilityType, int> parameters)
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
