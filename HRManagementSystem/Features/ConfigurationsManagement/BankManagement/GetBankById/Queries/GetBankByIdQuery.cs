using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.BankManagement.GetBankById.Queries
{
    public record GetBankByIdQuery(Guid Id) : IRequest<RequestResult<GetBankByIdDto>>;

    public class GetBankByIdQueryHandler : RequestHandlerBase<GetBankByIdQuery, RequestResult<GetBankByIdDto>, Bank, Guid>
    {
        public GetBankByIdQueryHandler(RequestHandlerBaseParameters<Bank, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<GetBankByIdDto>> Handle(GetBankByIdQuery request, CancellationToken ct)
        {
            var bank = await _generalRepo.GetByIdAsync(request.Id);

            if (bank == null)
                return RequestResult<GetBankByIdDto>.Failure("Bank not found.", ErrorCode.NotFound);

            var bankDto = _mapper.Map<GetBankByIdDto>(bank);

            return RequestResult<GetBankByIdDto>.Success(bankDto, "Bank retrieved successfully!");
        }
    }
}


