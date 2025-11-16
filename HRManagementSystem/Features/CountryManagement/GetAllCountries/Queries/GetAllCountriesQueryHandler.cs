using AutoMapper.QueryableExtensions;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CountryManagement.GetAllCountries.Queries
{
    public sealed class GetAllCountriesQueryHandler : RequestHandlerBase<GetAllCountriesQuery, RequestResult<List<ViewCountryDto>>, Country, Guid>
    {
        public GetAllCountriesQueryHandler(RequestHandlerBaseParameters<Country, Guid> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<List<ViewCountryDto>>> Handle(GetAllCountriesQuery request, CancellationToken ct)
        {
            var countryDtos = await _generalRepo
           .Get(x => !x.IsDeleted, ct)
           .OrderBy(x => x.Name) // ??? ????: sorting ?? ?? DB
           .ProjectTo<ViewCountryDto>(_mapper.ConfigurationProvider)
           .ToListAsync(ct);

            return RequestResult<List<ViewCountryDto>>.Success(countryDtos);
        }
    }
}

