using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.OrganizationManagement.GetOrganizationById.Queries
{
    public sealed record GetOrganizationByIdQuery(Guid Id) : IRequest<RequestResult<ViewOrganizationDto>>;

    public sealed class GetOrganizationByIdQueryHandler : RequestHandlerBase<GetOrganizationByIdQuery,
        RequestResult<ViewOrganizationDto>, Organization, Guid>
    {
        public GetOrganizationByIdQueryHandler(RequestHandlerBaseParameters<Organization, Guid> parameters)
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
