using HRManagementSystem.Features.CountryManagement.DeleteCountry.Commands;

namespace HRManagementSystem.Features.CountryManagement.DeleteCountry
{
    public class DeleteCountryEndPoint : BaseEndPoint<DeleteCountryViewModel, bool>
    {
        public DeleteCountryEndPoint(EndPointBaseParameters<DeleteCountryViewModel> parameters) : base(parameters) { }

        [HttpDelete("delete/{id:int}")]
        // نستخدم [FromRoute] الـ ID من 
        public async Task<ResponseViewModel<bool>> DeleteCountry([FromRoute] int id, CancellationToken ct)
        {
            var model = new DeleteCountryViewModel(id);

            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            // 3. إرسال الـ Command
            var result = await _mediator.Send(new DeleteCountryCommand(id), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Country Deleted Successfully!");
        }
    }
}
