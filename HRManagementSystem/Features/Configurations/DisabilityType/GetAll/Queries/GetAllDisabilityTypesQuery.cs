using HRManagementSystem.Features.Configurations.DisabilityType.AddDisabilityType;

namespace HRManagementSystem.Features.Configurations.DisabilityType.GetAll.Queries
{
    public sealed record GetAllDisabilityTypesQuery(bool IncludeInactive = false) : IRequest<RequestResult<IEnumerable<ViewDisabilityTypeDto>>>;
    // Queries/GetAllDisabilityTypesQueryHandler.cs
    public sealed class GetAllDisabilityTypesQueryHandler
        : RequestHandlerBase<GetAllDisabilityTypesQuery, RequestResult<IEnumerable<ViewDisabilityTypeDto>>,
          HRManagementSystem.Data.Models.ConfigurationOfSys.DisabilityType, int>
    {
        public GetAllDisabilityTypesQueryHandler(
            RequestHandlerBaseParameters<HRManagementSystem.Data.Models.ConfigurationOfSys.DisabilityType, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<IEnumerable<ViewDisabilityTypeDto>>> Handle(
            GetAllDisabilityTypesQuery request, CancellationToken ct)
        {
            // Build query based on include inactive flag
            var query = _generalRepo.GetAll()
                .Where(d => !d.IsDeleted);

            if (!request.IncludeInactive)
            {
                query = query.Where(d => d.IsActive);
            }

            // Order by name for consistent results
            query = query.OrderBy(d => d.Name);

            var disabilityTypes = query.ToList();

            var disabilityTypeDtos = _mapper.Map<IEnumerable<ViewDisabilityTypeDto>>(disabilityTypes);

            return RequestResult<IEnumerable<ViewDisabilityTypeDto>>.Success(
                disabilityTypeDtos,
                $"Retrieved {disabilityTypeDtos.Count()} disability type(s) successfully");
        }
    }
}
