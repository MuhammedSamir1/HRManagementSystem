using HRManagementSystem.Data.Models.Scopes;
using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.Common.AssignationManagement.AddAssignation.Orchestrator;

public class AddAssignationOrchestratorCommandHandler<ConfigEntity>
    : RequestHandlerBase<AddAssignationOrchestratorCommand<ConfigEntity>, RequestResult<CreatedIdDto>, ConfigEntity, Guid>
    where ConfigEntity : BaseModel<Guid>
{
    public AddAssignationOrchestratorCommandHandler(RequestHandlerBaseParameters<ConfigEntity, Guid> parameters)
        : base(parameters)
    {
    }
    public override async Task<RequestResult<CreatedIdDto>> Handle(AddAssignationOrchestratorCommand<ConfigEntity> request, CancellationToken ct)
    {
        var mapped = _mapper.Map<ConfigEntity>(request);
        var isAdded = await _generalRepo.AddAsync(mapped, ct);
        if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Assignation wasn't added successfully!",
            ErrorCode.InternalServerError);

        var createdIdDto = _mapper.Map<CreatedIdDto>(mapped);
        return RequestResult<CreatedIdDto>.Success(createdIdDto, "Assignation added successfully!");
    }
}


