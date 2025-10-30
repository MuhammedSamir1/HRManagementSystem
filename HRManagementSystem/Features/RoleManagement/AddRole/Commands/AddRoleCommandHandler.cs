namespace HRManagementSystem.Features.RoleManagement.AddRole.Commands
{
    public class AddRoleCommandHandler : RequestHandlerBase<AddRoleCommand, RequestResult<bool>, Role, Guid>
    {
        public AddRoleCommandHandler(
            RequestHandlerBaseParameters<Role, Guid> parameters
        ) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(AddRoleCommand request, CancellationToken ct)
        {
            var role = _mapper.Map<AddRoleCommand, Role>(request);

            var isAdded = await _generalRepo.AddAsync(role, ct);
            if (!isAdded)
                return RequestResult<bool>.Failure("Role wasn't Added successfully!", ErrorCode.InternalServerError);

            return RequestResult<bool>.Success(isAdded, "Role Added successfully!");
        }
    }
}
