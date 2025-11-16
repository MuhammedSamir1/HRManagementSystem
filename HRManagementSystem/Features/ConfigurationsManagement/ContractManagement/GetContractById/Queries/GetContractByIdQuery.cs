using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.GetContractById.Queries
{
    public record GetContractByIdQuery(Guid Id) : IRequest<RequestResult<GetContractByIdDto>>;

    public class GetContractByIdQueryHandler : RequestHandlerBase<GetContractByIdQuery, RequestResult<GetContractByIdDto>, Contract, Guid>
    {
        public GetContractByIdQueryHandler(RequestHandlerBaseParameters<Contract, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<GetContractByIdDto>> Handle(GetContractByIdQuery request, CancellationToken ct)
        {
            var contract = await _generalRepo.GetByIdAsync(request.Id);

            if (contract == null)
                return RequestResult<GetContractByIdDto>.Failure("Contract not found.", ErrorCode.NotFound);

            var contractDto = _mapper.Map<GetContractByIdDto>(contract);

            return RequestResult<GetContractByIdDto>.Success(contractDto, "Contract retrieved successfully!");
        }
    }
}


