using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using MediatR;

namespace HRManagementSystem.Features.DepartmentManagement.AddDepartment.Commands
{
    public record AddDepartmentCommand(
                                   int branchId, string name,
                                   string code, string? description)
                                   : IRequest<RequestResult<bool>>;

    public sealed class AddDepartmentCommandHandler : RequestHandlerBase<AddDepartmentCommand, RequestResult<bool>, Department, int>
    {
        public AddDepartmentCommandHandler(RequestHandlerBaseParameters<Department, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(AddDepartmentCommand request, CancellationToken ct)
        {
            var department = _mapper.Map<Department>(request);

            var isAdded = await _generalRepo.AddAsync(department, ct);

            if (!isAdded) return RequestResult<bool>.Failure("Department wasn't added successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isAdded, "Department added successfully!");
        }
    }
}
