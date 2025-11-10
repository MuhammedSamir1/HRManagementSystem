using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.UpdateContract.Commands
{
    public record UpdateContractCommand(
        int Id,
        string ContractNumber,
        string Title,
        string? Description,
        DateTime StartDate,
        DateTime EndDate,
        decimal ContractValue,
        ContractType ContractType,
        ContractStatus Status,
        int? EmployeeId,
        string? Terms) : IRequest<RequestResult<bool>>;

    public class UpdateContractCommandHandler : RequestHandlerBase<UpdateContractCommand, RequestResult<bool>, Contract, int>
    {
        public UpdateContractCommandHandler(RequestHandlerBaseParameters<Contract, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(UpdateContractCommand request, CancellationToken ct)
        {
            var contract = await _generalRepo.GetByIdAsync(request.Id);

            if (contract == null)
                return RequestResult<bool>.Failure("Contract not found.", ErrorCode.NotFound);

            _mapper.Map(request, contract);

            var isUpdated = await _generalRepo.UpdateAsync(contract, ct);

            if (!isUpdated) return RequestResult<bool>.Failure("Contract wasn't updated successfully!", ErrorCode.InternalServerError);

            return RequestResult<bool>.Success(isUpdated, "Contract updated successfully!");
        }
    }
}

