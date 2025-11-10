using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.AddContract.Commands
{
    public record AddContractCommand(
        string ContractNumber,
        string Title,
        string? Description,
        DateTime StartDate,
        DateTime EndDate,
        decimal ContractValue,
        ContractType ContractType,
        ContractStatus Status,
        int? EmployeeId,
        string? Terms) : IRequest<RequestResult<CreatedIdDto>>;

    public class AddContractCommandHandler : RequestHandlerBase<AddContractCommand, RequestResult<CreatedIdDto>, Contract, int>
    {
        public AddContractCommandHandler(RequestHandlerBaseParameters<Contract, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddContractCommand request, CancellationToken ct)
        {
            var contract = _mapper.Map<AddContractCommand, Contract>(request);

            var contractNumberExists = await _generalRepo.CheckAnyAsync(x => x.ContractNumber == request.ContractNumber, ct);
            if (contractNumberExists)
                return RequestResult<CreatedIdDto>.Failure("Contract Number already exists.", ErrorCode.Conflict);

            var isAdded = await _generalRepo.AddAsync(contract, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Contract wasn't added successfully!", ErrorCode.InternalServerError);

            var mapped = _mapper.Map<CreatedIdDto>(contract);
            return RequestResult<CreatedIdDto>.Success(mapped, "Contract added successfully!");
        }
    }
}

