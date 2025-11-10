using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.BankManagement.UpdateBank.Commands
{
    public record UpdateBankCommand(int Id, string Name, string Code, string Address) : IRequest<RequestResult<bool>>;

    public class UpdateBankCommandHandler : RequestHandlerBase<UpdateBankCommand, RequestResult<bool>, Bank, int>
    {
        public UpdateBankCommandHandler(RequestHandlerBaseParameters<Bank, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(UpdateBankCommand request, CancellationToken ct)
        {
            var bank = await _generalRepo.GetByIdAsync(request.Id);

            if (bank == null)
                return RequestResult<bool>.Failure("Bank not found.", ErrorCode.NotFound);

            _mapper.Map(request, bank);

            var isUpdated = await _generalRepo.UpdateAsync(bank, ct);

            if (!isUpdated) return RequestResult<bool>.Failure("Bank wasn't updated successfully!", ErrorCode.InternalServerError);

            return RequestResult<bool>.Success(isUpdated, "Bank updated successfully!");
        }
    }
}

