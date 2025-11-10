namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.DeleteDisabilityType.Queries
{
    // Queries/IsDisabilityTypeInUseQuery.cs
    public record IsDisabilityTypeInUseQuery(int DisabilityTypeId)
        : IRequest<RequestResult<bool>>;

    public sealed class IsDisabilityTypeInUseQueryHandler : RequestHandlerBase<IsDisabilityTypeInUseQuery, RequestResult<bool>, Employee, int>
    {

        public IsDisabilityTypeInUseQueryHandler(RequestHandlerBaseParameters<Employee, int> _parameters) : base(_parameters)
        {

        }

        public override async Task<RequestResult<bool>> Handle(
            IsDisabilityTypeInUseQuery request, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
