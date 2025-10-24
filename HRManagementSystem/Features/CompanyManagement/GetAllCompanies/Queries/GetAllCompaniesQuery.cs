using AutoMapper.QueryableExtensions;
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
            var companiesDto = await _generalRepo.GetAll()
                            .ProjectTo<GetAllCompaniesDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(ct);

            if (!companiesDto.Any())
                return RequestResult<IEnumerable<GetAllCompaniesDto>>.Failure("No companies!", ErrorCode.NotFound);

            return RequestResult<IEnumerable<GetAllCompaniesDto>>.Success(companiesDto, "Companies returned successfully!");
        }
    }
}



