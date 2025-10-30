using HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.Dtos;

namespace HRManagementSystem.Features.BranchManagement.UpdateBranch.Commands
{
    public sealed record UpdateBranchCommand(int Id, string Name, string? Description, string Code,
          UpdateBranchAddressDto AddressDto) : IRequest<RequestResult<bool>>;

    public class UpdateBranchCommandHandler : RequestHandlerBase<UpdateBranchCommand, RequestResult<bool>, Branch, int>
    {
        public UpdateBranchCommandHandler(RequestHandlerBaseParameters<Branch, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(UpdateBranchCommand request, CancellationToken ct)
        {
            //var isExist = await _mediator.Send(new IsBranchExistQuery(request.Id));
            //if (!isExist.isSuccess) return RequestResult<bool>.Failure("Branch not found.", ErrorCode.OrganizationNotFound);

            var nameExists = await _generalRepo.ExistsByNameAsync<Branch>(request.Name);
            if (nameExists)
                return RequestResult<bool>.Failure("Branch Name already exists.", ErrorCode.Conflict);

            var branch = _mapper.Map<UpdateBranchCommand, Branch>(request);
            var isUpdated = await _generalRepo.UpdatePartialAsync(branch, null, ct);

            if (!isUpdated) return RequestResult<bool>.Failure("Branch wasn't Updated successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isUpdated, "Branch Updated successfully!");
        }
    }
}
