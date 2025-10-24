using AutoMapper.QueryableExtensions;
using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.DepartmentManagement.GetDepartmentById.Queries
{
    public record GetDepartmentByIdQuery(int departmentId) : IRequest<RequestResult<GetDepartmentByIdDto>>;

    public sealed class GetDepartmentByIdQueryHandler : RequestHandlerBase<GetDepartmentByIdQuery, RequestResult<GetDepartmentByIdDto>, Department, int>
    {
        public GetDepartmentByIdQueryHandler(RequestHandlerBaseParameters<Department, int> parameters) : base(parameters)
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
