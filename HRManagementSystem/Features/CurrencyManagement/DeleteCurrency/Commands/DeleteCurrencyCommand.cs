namespace HRManagementSystem.Features.CurrencyManagement.DeleteCurrency.Commands
{
    public record DeleteCurrencyCommand(Guid currencyId) : IRequest<RequestResult<bool>>;

    public sealed class DeleteCurrencyCommandHandler : RequestHandlerBase<DeleteCurrencyCommand,
    RequestResult<bool>, Currency, Guid>
    {
        public DeleteCurrencyCommandHandler(RequestHandlerBaseParameters<Currency, Guid> parameters) : base(parameters)
        { }

        public override async Task<RequestResult<bool>> Handle(DeleteCurrencyCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.currencyId, ct);

            if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.OrganizationNotFound);
            return RequestResult<bool>.Success(isDeleted);
        }
    }
}

