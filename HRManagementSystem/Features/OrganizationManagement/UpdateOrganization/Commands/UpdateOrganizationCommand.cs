using HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.UpdateCurrencyDtosAndVms.Dtos;
using HRManagementSystem.Features.Common.OrganizationCommon.Queries;

namespace HRManagementSystem.Features.OrganizationManagement.UpdateOrganization.Commands
{
    public sealed record UpdateOrganizationCommand(int Id, string Name, string? LegalName, string? Industry, string? Descreption,
        UpdateOrganizationCurrencyDto CurrencyDto, UpdateOrganizationAddressDto AddressDto) : IRequest<RequestResult<bool>>;


    public class UpdateOrganizationCommandHandler : RequestHandlerBase<UpdateOrganizationCommand, RequestResult<bool>, Organization, int>
    {
        public UpdateOrganizationCommandHandler(RequestHandlerBaseParameters<Organization, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(UpdateOrganizationCommand request, CancellationToken ct)
        {
            var isExist = await _mediator.Send(new IsOrganizationExistQuery(request.Id));
            if (!isExist.isSuccess) return RequestResult<bool>.Failure("Organization not found.", ErrorCode.OrganizationNotFound);

            var nameExists = await _generalRepo.ExistsByNameAsync<Branch>(request.Name);

            if (nameExists)
                return RequestResult<bool>.Failure("Organization Name already exists.", ErrorCode.Conflict);

            var organization = _mapper.Map<UpdateOrganizationCommand, Organization>(request);
            var isUpdated = await _generalRepo.UpdateAsync(organization, ct);

            if (!isUpdated) return RequestResult<bool>.Failure("Organization wasn't Updated successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isUpdated, "Organization Updated successfully!");
        }
    }
}
