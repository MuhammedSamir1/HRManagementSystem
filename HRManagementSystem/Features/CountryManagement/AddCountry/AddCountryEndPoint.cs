using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.ViewModels;
using HRManagementSystem.Features.CountryManagement.AddCountry.Commands;

namespace HRManagementSystem.Features.CountryManagement.AddCountry
{
    [ApiGroup("Country Management")]
    public class AddCountryEndPoint : BaseEndPoint<AddCountryViewModel, ViewCountryViewModel>
    {
        public AddCountryEndPoint(EndPointBaseParameters<AddCountryViewModel> parameters) : base(parameters) { }

        [HttpPost("add")]
        public async Task<ResponseViewModel<ViewCountryViewModel>> AddCountry([FromQuery] AddCountryViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewCountryViewModel>.Failure(validationResult.errorCode);
            }

            //  تحويل ViewModel إلى Command
            var command = _mapper.Map<AddCountryCommand>(model);

            // إرسال  Command
            var result = await _mediator.Send(command, ct);
            var mapedData = _mapper.Map<ViewCountryViewModel>(result.data);
            if (!result.isSuccess) return ResponseViewModel<ViewCountryViewModel>.Failure(ErrorCode.BadRequest);

            return ResponseViewModel<ViewCountryViewModel>.Success(mapedData, "Country Added Successfully!");
        }
    }
}

