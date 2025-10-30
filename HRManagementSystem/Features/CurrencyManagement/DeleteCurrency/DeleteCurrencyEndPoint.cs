using HRManagementSystem.Features.CurrencyManagement.DeleteCurrency.Commands;

namespace HRManagementSystem.Features.CurrencyManagement.DeleteCurrency
{
    public class DeleteCurrencyEndPoint : BaseEndPoint<DeleteCurrencyRequestViewModel, ResponseViewModel<bool>>
    {
        public DeleteCurrencyEndPoint(EndPointBaseParameters<DeleteCurrencyRequestViewModel> parameters)
                 : base(parameters) { }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> DeleteCurrency(DeleteCurrencyRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);

            var isDeleted = await _mediator.Send(new DeleteCurrencyCommand(model.currencyId));
            if (!isDeleted.isSuccess) return ResponseViewModel<bool>.Failure(ErrorCode.NotFound);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Company Deleted Successfully!");
        }
    }
}
