using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.DepartmentManagement.AddDepartment.Commands
{
    public record AddDepartmentCommand(
                                   int branchId, string name,
                                   string code, string? description)
                                   : IRequest<RequestResult<CreatedIdDto>>;

    public sealed class AddDepartmentCommandHandler : RequestHandlerBase<AddDepartmentCommand, RequestResult<CreatedIdDto>, Department, int>
    {
        public AddDepartmentCommandHandler(RequestHandlerBaseParameters<Department, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddDepartmentCommand request, CancellationToken ct)
        {
            var department = _mapper.Map<Department>(request);

            var isAdded = await _generalRepo.AddAsync(department, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Department wasn't added successfully!", ErrorCode.InternalServerError);

            var createdIdDto = _mapper.Map<CreatedIdDto>(department);
            return RequestResult<CreatedIdDto>.Success(createdIdDto, "Department added successfully!");
        }
    }
}
