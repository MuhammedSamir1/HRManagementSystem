using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.Common.AssignationManagement.AddAssignation.Orchestrator;

public sealed record AddAssignationOrchestratorCommand<ConfigEntity>(Guid configId, Guid scopeId) : IRequest<RequestResult<CreatedIdDto>>;

