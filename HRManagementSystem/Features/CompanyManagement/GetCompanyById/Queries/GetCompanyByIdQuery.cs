using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.CompanyManagement.GetAllCompany;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CompanyManagement.GetCompanyById.Queries
{
    public record GetCompanyByIdQuery(int companyId) : IRequest<RequestResult<GetCompanyByIdDto>>;

    public sealed class GetCompanyByIdQueryHandler : RequestHandlerBase<GetCompanyByIdQuery, RequestResult<GetCompanyByIdDto>, Company, int>
    {
        public GetCompanyByIdQueryHandler(RequestHandlerBaseParameters<Company, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<GetCompanyByIdDto>> Handle(GetCompanyByIdQuery request, CancellationToken ct)
        {
            var company = await _generalRepo.GetById(request.companyId)
                        .Select(x => new GetCompanyByIdDto
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Code = x.Code,
                            Description = x.Description,
                            OrganizationName = x.Organization.Name
                        })
                        .FirstOrDefaultAsync(ct);

            if (company is null)
                return RequestResult<GetCompanyByIdDto>.Failure($"Not found company with id: {request.companyId}", ErrorCode.NotFound);

            var companyDto = _mapper.Map<GetCompanyByIdDto>(company);

            return RequestResult<GetCompanyByIdDto>.Success(companyDto, "Company returned successfully!");
        }

    }
}
