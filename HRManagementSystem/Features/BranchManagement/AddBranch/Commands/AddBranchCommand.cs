using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos;

namespace HRManagementSystem.Features.BranchManagement.AddBranch.Commands
{
    public sealed record AddBranchCommand(string Name, string? Description, int CompanyId,
        string Code, AddBranchAddressDto AddressDto) : IRequest<RequestResult<bool>>;


    public class AddBranchCommandHandler : RequestHandlerBase<AddBranchCommand, RequestResult<bool>, Branch, int>
    {
        public AddBranchCommandHandler(RequestHandlerBaseParameters<Branch, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(AddBranchCommand request, CancellationToken ct)
        {
            var branch = _mapper.Map<AddBranchCommand, Branch>(request);

            var nameExists = await _generalRepo.ExistsByNameAsync<Branch>(request.Name);
            if (nameExists)
                return RequestResult<bool>.Failure("Branch Name already exists.", ErrorCode.Conflict);

            var isAdded = await _generalRepo.AddAsync(branch, ct);

            if (!isAdded) return RequestResult<bool>.Failure("Branch wasn't added successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isAdded, "Branch added successfully!");
        }
    }
}
