using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.CityManagement.DeleteCity.Commands;
using HRManagementSystem.Features.CityManagement.DeleteCity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.CityManagement.DeleteCity
{
    public class DeleteCityEndPoint
        : BaseEndPoint<DeleteCityViewModel, ResponseViewModel<bool>>
    {
        public DeleteCityEndPoint(EndPointBaseParameters<DeleteCityViewModel> parameters)
            : base(parameters) { }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> DeleteCity(DeleteCityViewModel model, CancellationToken ct)
        {
            // ✅ Validate request
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);

            // 🚀 Execute command
            var isDeleted = await _mediator.Send(new DeleteCityCommand(model.Id), ct);
            if (!isDeleted.isSuccess)
                return ResponseViewModel<bool>.Failure(ErrorCode.CityWasNotDeleted);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "City deleted successfully!");
        }
    }
}
