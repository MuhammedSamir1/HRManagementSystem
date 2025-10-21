using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CompanyManagement.GetAllCompany.Queries
{
    public record GetAllCompaniesQuery() : IRequest<RequestResult<IEnumerable<GetAllCompaniesDto>>>;

    public sealed class GetAllCompaniesQueryHandler : RequestHandlerBase<GetAllCompaniesQuery, RequestResult<IEnumerable<GetAllCompaniesDto>>, Company, int>
    {
        public GetAllCompaniesQueryHandler(RequestHandlerBaseParameters<Company, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<IEnumerable<GetAllCompaniesDto>>> Handle(GetAllCompaniesQuery request, CancellationToken ct)
        {
            var companies = await _generalRepo.GetAll()
                                    .Select(x => new GetAllCompaniesDto
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Code = x.Code,
                                        Description = x.Description,
                                        OrganizationName = x.Organization.Name
                                    })
                                    .ToListAsync(ct);

            if (!companies.Any())
                return RequestResult<IEnumerable<GetAllCompaniesDto>>.Failure("No companies!", ErrorCode.NotFound);

            return RequestResult<IEnumerable<GetAllCompaniesDto>>.Success(companies, "Companies returned successfully!");
        }
    }
}



