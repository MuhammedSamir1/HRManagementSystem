using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos;
using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.BranchManagement.AddBranch.Commands
{
    public sealed record AddBranchCommand(string Name, string? Description, int CompanyId,
        string Code, AddBranchAddressDto AddressDto) : IRequest<RequestResult<CreatedIdDto>>;


    public class AddBranchCommandHandler : RequestHandlerBase<AddBranchCommand, RequestResult<CreatedIdDto>, Branch, int>
    {
        public AddBranchCommandHandler(RequestHandlerBaseParameters<Branch, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddBranchCommand request, CancellationToken ct)
        {
            var branch = _mapper.Map<AddBranchCommand, Branch>(request);

            var nameExists = await _generalRepo.ExistsByNameAsync<Branch>(request.Name);
            if (nameExists)
                return RequestResult<CreatedIdDto>.Failure("Branch Name already exists.", ErrorCode.Conflict);

            var isAdded = await _generalRepo.AddAsync(branch, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Branch wasn't added successfully!", ErrorCode.InternalServerError);

            var mapped = _mapper.Map<CreatedIdDto>(branch);
            return RequestResult<CreatedIdDto>.Success(mapped, "Branch added successfully!");
        }
    }
}
