namespace HRManagementSystem.Features.RoleFeatureManagement.AssignFeatureToRole.Commands
{
    public class AssignFeatureToRoleCommandHandler : RequestHandlerBase<AssignFeatureToRoleCommand, RequestResult<bool>, RoleFeature, Guid>
    {
        public AssignFeatureToRoleCommandHandler(
            RequestHandlerBaseParameters<RoleFeature, Guid> parameters
        ) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(AssignFeatureToRoleCommand request, CancellationToken ct)
        {
            var roleFeature = _mapper.Map<AssignFeatureToRoleCommand, RoleFeature>(request);

            var isAdded = await _generalRepo.AddAsync(roleFeature, ct);
            if (!isAdded)
                return RequestResult<bool>.Failure("wasn't Added successfully!", ErrorCode.InternalServerError);

            return RequestResult<bool>.Success(isAdded, "Added successfully!");
        }
    }
}
