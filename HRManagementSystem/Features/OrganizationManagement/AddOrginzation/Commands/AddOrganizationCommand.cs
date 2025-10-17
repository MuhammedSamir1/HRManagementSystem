using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.Common.AddressManagement;
using MediatR;

namespace HRManagementSystem.Features.OrganizationManagement.AddOrganization.Commands
{
    public record AddOrganizationCommand(string Name, string? LegalName, string? Industry,
        string? DefaultTimezone, string? DefaultCurrency, AddAddressDto AddressDto) : IRequest<ResponseDto<bool>>;

    public class AddOrganizationCommandHandler : RequestHandlerBase<AddOrganizationCommand, ResponseDto<bool>, Organization, int>
    {
        public AddOrganizationCommandHandler(RequestHandlerBaseParameters<Organization, int> parameters) : base(parameters)
        {
        }

        public override async Task<ResponseDto<bool>> Handle(AddOrganizationCommand request, CancellationToken ct)
        {
            var organization = _mapper.Map<AddOrganizationCommand, Organization>(request);

            var isAdded = await _generalRepo.AddAsync(organization, ct);

            if (!isAdded) return ResponseDto<bool>.Failure("Organization wasn't added successfully!", ErrorCode.InternalServerError);
            return ResponseDto<bool>.Success(isAdded, "Organization added successfully!");
        }
    }
}
