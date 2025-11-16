using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.DepartmentManagement.GetDepartmentById.Queries
{
    public record GetDepartmentByIdQuery(Guid departmentId) : IRequest<RequestResult<GetDepartmentByIdDto>>;

    public sealed class GetDepartmentByIdQueryHandler : RequestHandlerBase<GetDepartmentByIdQuery, RequestResult<GetDepartmentByIdDto>, Department, Guid>
    {
        public GetDepartmentByIdQueryHandler(RequestHandlerBaseParameters<Department, Guid> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<GetDepartmentByIdDto>> Handle(GetDepartmentByIdQuery request, CancellationToken ct)
        {
            var departmentDto = await _generalRepo.GetById(request.departmentId)
                            .ProjectTo<GetDepartmentByIdDto>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(ct);

            if (departmentDto is null)
                return RequestResult<GetDepartmentByIdDto>.Failure($"Not found department with id: {request.departmentId}", ErrorCode.NotFound);

            return RequestResult<GetDepartmentByIdDto>.Success(departmentDto, "Department returned successfully!");
        }

    }
}

