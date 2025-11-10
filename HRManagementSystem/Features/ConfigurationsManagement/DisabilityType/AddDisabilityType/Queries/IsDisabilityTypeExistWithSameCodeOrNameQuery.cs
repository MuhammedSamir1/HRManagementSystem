namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.AddDisabilityType.Queries
{
    public record IsDisabilityTypeExistWithSameCodeOrNameQuery(string Name, string Code) : IRequest<RequestResult<bool>>;

    public sealed class IsDisabilityTypeExistWithSameCodeOrNameQueryHandler
    : RequestHandlerBase<IsDisabilityTypeExistWithSameCodeOrNameQuery, RequestResult<bool>, Data.Models.ConfigurationOfSys.DisabilityType, int>
    {
        public IsDisabilityTypeExistWithSameCodeOrNameQueryHandler(RequestHandlerBaseParameters<Data.Models.ConfigurationOfSys.DisabilityType, int> _params) : base(_params) { }
        public override async Task<RequestResult<bool>> Handle(IsDisabilityTypeExistWithSameCodeOrNameQuery request, CancellationToken cancellationToken)
        {
            var existingType = await _generalRepo.CheckAnyAsync(D => (D.Code == request.Code || D.Name == request.Name) && !D.IsDeleted, cancellationToken);

            if (!existingType)
                return RequestResult<bool>.Failure("This DisabilityType doesn't exist before", ErrorCode.NotFound);

            return RequestResult<bool>.Success(true, "There is Already exist Diability Type With Same Code Or Same Name");
        }
    }

}
