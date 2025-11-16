using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.DepartmentManagement.GetAllDepartments.Queries
{
    public record GetAllDepartmentsQuery() : IRequest<RequestResult<IEnumerable<GetAllDepartmentsDto>>>;

    public sealed class GetAllDepartmentsQueryHandler : RequestHandlerBase<GetAllDepartmentsQuery, RequestResult<IEnumerable<GetAllDepartmentsDto>>, Department, Guid>
    {
        public GetAllDepartmentsQueryHandler(RequestHandlerBaseParameters<Department, Guid> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<IEnumerable<GetAllDepartmentsDto>>> Handle(GetAllDepartmentsQuery request, CancellationToken ct)
        {
            var departmentsDto = await _generalRepo.GetAll()
                            .ProjectTo<GetAllDepartmentsDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(ct);

            if (!departmentsDto.Any())
                return RequestResult<IEnumerable<GetAllDepartmentsDto>>.Failure("No departments!", ErrorCode.NotFound);

            return RequestResult<IEnumerable<GetAllDepartmentsDto>>.Success(departmentsDto, "Companies returned successfully!");
        }
    }
}

