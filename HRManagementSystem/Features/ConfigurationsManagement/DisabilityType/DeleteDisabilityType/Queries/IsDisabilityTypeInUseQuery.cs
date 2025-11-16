namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.DeleteDisabilityType.Queries
{
    // Queries/IsDisabilityTypeInUseQuery.cs
    public record IsDisabilityTypeInUseQuery(Guid DisabilityTypeId)
        : IRequest<RequestResult<bool>>;

    public sealed class IsDisabilityTypeInUseQueryHandler : RequestHandlerBase<IsDisabilityTypeInUseQuery, RequestResult<bool>, Employee, Guid>
    {

        public IsDisabilityTypeInUseQueryHandler(RequestHandlerBaseParameters<Employee, Guid> _parameters) : base(_parameters)
        {

        }

        public override async Task<RequestResult<bool>> Handle(
            IsDisabilityTypeInUseQuery request, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}

