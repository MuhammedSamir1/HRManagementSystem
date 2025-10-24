using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using HRManagementSystem.Features.CountryManagement.UpdateCountry.Commands;
using HRManagementSystem.Features.CountryManagement.ViewModels.UpdateCountry;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.CountryManagement.UpdateCountry
{
    public class UpdateCountryEndPoint : BaseEndPoint<UpdateCountryViewModel, ViewCountryDto>
    {
        public UpdateCountryEndPoint(EndPointBaseParameters<UpdateCountryViewModel> parameters) : base(parameters) { }

        [HttpPut("update")]
        public async Task<ResponseViewModel<ViewCountryDto>> UpdateCountry([FromQuery] UpdateCountryViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewCountryDto>.Failure(validationResult.errorCode);
            }

            var command = _mapper.Map<UpdateCountryCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess) return ResponseViewModel<ViewCountryDto>.Failure(result.errorCode);
            return ResponseViewModel<ViewCountryDto>.Success(result.data, "Country Updated Successfully!");
        }
    }
}
