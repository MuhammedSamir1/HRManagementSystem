using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.BankManagement.AddBank.Commands
{
    public record AddBankCommand(string Name, string Code, string Address) : IRequest<RequestResult<CreatedIdDto>>;

    public class AddBankCommandHandler : RequestHandlerBase<AddBankCommand, RequestResult<CreatedIdDto>, Bank, int>
    {
        public AddBankCommandHandler(RequestHandlerBaseParameters<Bank, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddBankCommand request, CancellationToken ct)
        {
            var bank = _mapper.Map<AddBankCommand, Bank>(request);

            var nameExists = await _generalRepo.ExistsByNameAsync<Bank>(request.Name);
            if (nameExists)
                return RequestResult<CreatedIdDto>.Failure("Bank Name already exists.", ErrorCode.Conflict);

            var isAdded = await _generalRepo.AddAsync(bank, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Bank wasn't added successfully!", ErrorCode.InternalServerError);

            var mapped = _mapper.Map<CreatedIdDto>(bank);
            return RequestResult<CreatedIdDto>.Success(mapped, "Bank added successfully!");
        }
    }
}

