using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.BaseRequestHandler;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Data.Repositories;
using HRManagementSystem.Features.Common.AddressManagement;
using MediatR;

namespace HRManagementSystem.Features.OrganizationManagement.AddOrganization.Commands
{
    public record AddOrganizationCommand(string Name, string? LegalName, string? Industry,
        string? DefaultTimezone, string? DefaultCurrency, AddAddressDto AddressDto) : IRequest<ResponseDto<bool>>;




    public class AddOrganizationCommandHandler : RequestHandlerBase<AddOrganizationCommand, ResponseDto<bool>, Organization>
    {
        private readonly IGeneralRepository<Organization> _repo;

        public AddOrganizationCommandHandler(RequestHandlerBaseParameters<Organization> parameters) : base(parameters)
        {
            _repo = parameters.GeneralRepository;
        }
        public override async Task<ResponseDto<bool>> Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
        {
            //var isExist = await _mediator.Send(new IsOrganizationExistQuery(request.Name), cancellationToken);
            //if (!isExist.isSuccess) return ResponseDto<bool>.Failure(
            //    "Organization Already Exists!", ErrorCode.OrganizationAlreadyExists);

            var organization = _mapper.Map<AddOrganizationCommand, Organization>(request);
            var isAdded = await _repo.AddAsync(organization);
            if (!isAdded) return ResponseDto<bool>.Failure("Organization wasn't added successfully!", ErrorCode.InternalServerError);
            return ResponseDto<bool>.Success(isAdded, "Organization added successfully!");
        }
    }
}
