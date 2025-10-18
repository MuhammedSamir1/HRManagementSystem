using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtos.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement;
using MediatR;

namespace HRManagementSystem.Features.OrganizationManagement.AddOrganization.Commands
{
    public record AddOrganizationCommand(string Name, string? LegalName, string? Industry,string? Descreption,
        DateTime? DefaultTimezone, AddOrganizationCurrencyDto CurrencyDto,
        AddOrganizationAddressDto AddressDto) : IRequest<RequestResult<bool>>;

    public class AddOrganizationCommandHandler : RequestHandlerBase<AddOrganizationCommand, RequestResult<bool>, Organization, int>
    {
        public AddOrganizationCommandHandler(RequestHandlerBaseParameters<Organization, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(AddOrganizationCommand request, CancellationToken ct)
        {
            var organization = _mapper.Map<AddOrganizationCommand, Organization>(request);

            var isAdded = await _generalRepo.AddAsync(organization, ct);

            if (!isAdded) return RequestResult<bool>.Failure("Organization wasn't added successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isAdded, "Organization added successfully!");
        }
    }
}
