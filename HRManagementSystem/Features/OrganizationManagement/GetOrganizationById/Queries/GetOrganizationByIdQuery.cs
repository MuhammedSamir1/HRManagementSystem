using AutoMapper.QueryableExtensions;
using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.OrganizationManagement.GetOrganizationById.Queries
{
    public sealed record GetOrganizationByIdQuery(int Id) : IRequest<RequestResult<ViewOrganizationDto>>;

    public sealed class GetOrganizationByIdQueryHandler : RequestHandlerBase<GetOrganizationByIdQuery,
        RequestResult<ViewOrganizationDto>, Organization, int>
    {
        public GetOrganizationByIdQueryHandler(RequestHandlerBaseParameters<Organization, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewOrganizationDto>> Handle(GetOrganizationByIdQuery request, CancellationToken ct)
        {
            var organization = await _generalRepo.Get(x => x.Id == request.Id && !x.IsDeleted, ct)
                .ProjectTo<ViewOrganizationDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(ct);

            if (organization is null)
                return RequestResult<ViewOrganizationDto>.Failure(ErrorCode.OrganizationNotFound);

            return RequestResult<ViewOrganizationDto>.Success(organization);
        }
    }
}
