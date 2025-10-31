using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.CompanyManagement.AddCompany.Commands
{
    public record AddCompanyCommand(
                                    int organizationId, string name,
                                    string code, string? description)
                                    : IRequest<RequestResult<CreatedIdDto>>;

    public sealed class AddCompanyCommandHandler : RequestHandlerBase<AddCompanyCommand, RequestResult<CreatedIdDto>, Company, int>
    {
        public AddCompanyCommandHandler(RequestHandlerBaseParameters<Company, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddCompanyCommand request, CancellationToken ct)
        {
            var company = _mapper.Map<Company>(request);

            var isAdded = await _generalRepo.AddAsync(company, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Company wasn't added successfully!", ErrorCode.InternalServerError);

            var mapped = _mapper.Map<CreatedIdDto>(company);
            return RequestResult<CreatedIdDto>.Success(mapped, "Company added successfully!");
        }
    }
}
