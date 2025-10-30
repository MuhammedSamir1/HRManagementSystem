using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CountryManagement.GetAllCountries
{
    public sealed class GetAllCountriesQueryHandler : RequestHandlerBase<GetAllCountriesQuery, ResponseViewModel<List<ViewCountryDto>>, Country, int>
    {
        public GetAllCountriesQueryHandler(RequestHandlerBaseParameters<Country, int> parameters) : base(parameters)
        {
        }

        public override async Task<ResponseViewModel<List<ViewCountryDto>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {

            var countries = await _generalRepo.GetAll()
                                            //.ProjectTo              
                                            .OrderBy(c => c.Name)
                                            .ToListAsync(cancellationToken);

            //  تحويل   Entities إلى قائمة DTOs
            var countryDtos = _mapper.Map<List<ViewCountryDto>>(countries);

            return ResponseViewModel<List<ViewCountryDto>>.Success(countryDtos);
        }
    }
}
