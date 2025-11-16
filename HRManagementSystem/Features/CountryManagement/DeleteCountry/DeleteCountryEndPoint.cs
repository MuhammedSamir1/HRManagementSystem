using HRManagementSystem.Features.CountryManagement.DeleteCountry.Commands;

namespace HRManagementSystem.Features.CountryManagement.DeleteCountry
{
    [ApiGroup("Country Management")]
    public class DeleteCountryEndPoint : BaseEndPoint<DeleteCountryViewModel, bool>
    {
        public DeleteCountryEndPoint(EndPointBaseParameters<DeleteCountryViewModel> parameters) : base(parameters) { }

        [HttpDelete("delete/{id:int}")]
        // ?????? [FromRoute] ??? ID ?? 
        public async Task<ResponseViewModel<bool>> DeleteCountry([FromRoute] Guid id, CancellationToken ct)
        {
            var model = new DeleteCountryViewModel(id);

            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            // 3. ????? ??? Command
            var result = await _mediator.Send(new DeleteCountryCommand(id), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Country Deleted Successfully!");
        }
    }
}


