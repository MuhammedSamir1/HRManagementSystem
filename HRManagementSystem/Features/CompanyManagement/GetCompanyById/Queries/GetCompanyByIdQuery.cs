using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CompanyManagement.GetCompanyById.Queries
{
    public record GetCompanyByIdQuery(Guid companyId) : IRequest<RequestResult<GetCompanyByIdDto>>;

    public sealed class GetCompanyByIdQueryHandler : RequestHandlerBase<GetCompanyByIdQuery, RequestResult<GetCompanyByIdDto>, Company, Guid>
    {
        public GetCompanyByIdQueryHandler(RequestHandlerBaseParameters<Company, Guid> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<GetCompanyByIdDto>> Handle(GetCompanyByIdQuery request, CancellationToken ct)
        {
            var companyDto = await _generalRepo.GetById(request.companyId)
                            .ProjectTo<GetCompanyByIdDto>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(ct);

            if (companyDto is null)
                return RequestResult<GetCompanyByIdDto>.Failure($"Not found company with id: {request.companyId}", ErrorCode.NotFound);

            return RequestResult<GetCompanyByIdDto>.Success(companyDto, "Company returned successfully!");
        }

    }
}

