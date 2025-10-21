using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.UpdateCurrencyDtosAndVms.Dtos;
using HRManagementSystem.Features.Common.OrganizationCommon.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

            var nameExists = await _generalRepo.Get(x => x.Name == request.Name && x.Id != request.Id && !x.IsDeleted)
                                          .AnyAsync(ct);

            if (nameExists)
                return RequestResult<bool>.Failure("Organization Name already exists.", ErrorCode.Conflict);

            var organization = _mapper.Map<UpdateOrganizationCommand, Organization>(request);
            var isUpdated = await _generalRepo.UpdateAsync(organization, ct);

            if (!isUpdated) return RequestResult<bool>.Failure("Organization wasn't Updated successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isUpdated, "Organization Updated successfully!");
        }
    }
}
