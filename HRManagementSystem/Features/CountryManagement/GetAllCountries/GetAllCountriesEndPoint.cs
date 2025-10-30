using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;

namespace HRManagementSystem.Features.CountryManagement.GetAllCountries
{
    public class GetAllCountriesEndPoint : BaseEndPoint<bool, List<ViewCountryDto>>
    {
        public GetAllCountriesEndPoint(EndPointBaseParameters<bool> parameters) : base(parameters) { }

        [HttpGet("all")] // GET api/country/all
        public async Task<ResponseViewModel<List<ViewCountryDto>>> GetAllCountries(CancellationToken ct)
        {
            // 1. إرسال الـ Query بدون مدخلات
            var result = await _mediator.Send(new GetAllCountriesQuery(), ct);

            if (!result.isSuccess) return ResponseViewModel<List<ViewCountryDto>>.Failure(result.errorCode);
            return ResponseViewModel<List<ViewCountryDto>>.Success(result.data);
        }
    }
}
