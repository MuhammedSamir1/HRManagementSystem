using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.ViewModels;
using HRManagementSystem.Features.CountryManagement.UpdateCountry.Commands;
using HRManagementSystem.Features.CountryManagement.ViewModels.UpdateCountry;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.CountryManagement.UpdateCountry
{
    public class UpdateCountryEndPoint : BaseEndPoint<UpdateCountryViewModel, ViewCountryViewModel>
    {
        public UpdateCountryEndPoint(EndPointBaseParameters<UpdateCountryViewModel> parameters) : base(parameters) { }

        [HttpPut("update")]
        public async Task<ResponseViewModel<ViewCountryViewModel>> UpdateCountry([FromQuery] UpdateCountryViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewCountryViewModel>.Failure(validationResult.errorCode);
            }

            var command = _mapper.Map<UpdateCountryCommand>(model);
            var result = await _mediator.Send(command, ct);
            var mapedData = _mapper.Map<ViewCountryViewModel>(result.data);

            if (!result.isSuccess) return ResponseViewModel<ViewCountryViewModel>.Failure(ErrorCode.BadRequest);
            return ResponseViewModel<ViewCountryViewModel>.Success(mapedData, "Country Updated Successfully!");
        }
    }
}
