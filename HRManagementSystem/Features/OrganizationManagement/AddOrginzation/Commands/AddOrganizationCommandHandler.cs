using HRManagementSystem.Features.Common.Dtos;
using HRManagementSystem.Features.OrganizationManagement.AddOrganization.Commands;

namespace HRManagementSystem.Features.OrganizationManagement.AddOrginzation.Commands;

public sealed class AddOrganizationCommandHandler : RequestHandlerBase<AddOrganizationCommand,
        RequestResult<CreatedIdDto>, Organization, int>
{
    public AddOrganizationCommandHandler(RequestHandlerBaseParameters<Organization, int> parameters) : base(parameters)
    {
    }

    public override async Task<RequestResult<CreatedIdDto>> Handle(AddOrganizationCommand request, CancellationToken ct)
    {
        var organization = _mapper.Map<AddOrganizationCommand, Organization>(request);

        var nameExists = await _generalRepo.ExistsByNameAsync<Organization>(request.Name);

        if (nameExists)
            return RequestResult<CreatedIdDto>.Failure("Organization Name already exists.", ErrorCode.Conflict);

        var isAdded = await _generalRepo.AddAsync(organization, ct);

        if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Organization wasn't added successfully!", ErrorCode.InternalServerError);

        var mapped = _mapper.Map<CreatedIdDto>(organization);
        return RequestResult<CreatedIdDto>.Success(mapped, "Organization added successfully!");
    }
}