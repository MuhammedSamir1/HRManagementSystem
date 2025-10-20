using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.OrganizationManagement.AddOrganization.Commands
{
    public record AddOrganizationCommand(string Name, string? LegalName, string? Industry, string? Description,
        DateTime? DefaultTimezone, AddOrganizationCurrencyDto CurrencyDto,
        AddOrganizationAddressDto AddressDto) : IRequest<RequestResult<bool>>;

    public sealed class AddOrganizationCommandHandler : RequestHandlerBase<AddOrganizationCommand,
        RequestResult<bool>, Organization, int>
    {
        public AddOrganizationCommandHandler(RequestHandlerBaseParameters<Organization, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(AddOrganizationCommand request, CancellationToken ct)
        {
            var organization = _mapper.Map<AddOrganizationCommand, Organization>(request);

            var nameExists = await _generalRepo.Get(x => x.Name == request.Name && !x.IsDeleted, ct)
                                          .AnyAsync(ct);
            if (nameExists)
                return RequestResult<bool>.Failure("Organization Name already exists.", ErrorCode.Conflict);

            var isAdded = await _generalRepo.AddAsync(organization, ct);

            if (!isAdded) return RequestResult<bool>.Failure("Organization wasn't added successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isAdded, "Organization added successfully!");
        }
    }
}
