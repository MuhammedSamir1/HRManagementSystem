namespace HRManagementSystem.Features.CurrencyManagement.AddCurrency.Commands
{
    public record AddCurrencyCommand(
                                    string Code, int NumericCode,
                                    string Name, string Symbol)
                                    : IRequest<RequestResult<bool>>;

    public sealed class AddCurrencyCommandHandler : RequestHandlerBase<AddCurrencyCommand, RequestResult<bool>, Currency, Guid>
    {
        public AddCurrencyCommandHandler(RequestHandlerBaseParameters<Currency, Guid> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(AddCurrencyCommand request, CancellationToken ct)
        {
            var currency = _mapper.Map<Currency>(request);

            var isAdded = await _generalRepo.AddAsync(currency, ct);

            if (!isAdded) return RequestResult<bool>.Failure("Currency wasn't added successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isAdded, "Currency added successfully!");
        }
    }
}

