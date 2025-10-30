namespace HRManagementSystem.Features.Common.CountryCommon.Queries
{
    public sealed record IsCountryExistQuery(string Iso3) : IRequest<RequestResult<bool>>;
}
