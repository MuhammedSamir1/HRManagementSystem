using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.CountryManagement.GetAllCountries
{
    public class GetAllCountriesEndPoint : BaseEndPoint<GetAllCountriesViewModel, ViewCountryViewModel>
    {
        public GetAllCountriesEndPoint(EndPointBaseParameters<GetAllCountriesViewModel> parameters) : base(parameters) { }

        [HttpGet] // GET api/country/all
        public async Task<ResponseViewModel<List<ViewCountryViewModel>>> GetAllCountries(CancellationToken ct)
        {
            // 1. إرسال الـ Query بدون مدخلات
            var result = await _mediator.Send(new GetAllCountriesQuery(), ct);

            if (result is null) return ResponseViewModel<List<ViewCountryViewModel>>.Failure(ErrorCode.NoCountriesFound);

            var mapped = _mapper.Map<List<ViewCountryViewModel>>(result.data);
            return ResponseViewModel<List<ViewCountryViewModel>>.Success(mapped);
        }
    }
}
