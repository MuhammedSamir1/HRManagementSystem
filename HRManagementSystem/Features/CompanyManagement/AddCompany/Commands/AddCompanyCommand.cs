namespace HRManagementSystem.Features.CompanyManagement.AddCompany.Commands
{
    public record AddCompanyCommand(
                                    int organizationId, string name,
                                    string code, string? description)
                                    : IRequest<RequestResult<bool>>;

    public sealed class AddCompanyCommandHandler : RequestHandlerBase<AddCompanyCommand, RequestResult<bool>, Company, int>
    {
        public AddCompanyCommandHandler(RequestHandlerBaseParameters<Company, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(AddCompanyCommand request, CancellationToken ct)
        {
            var company = _mapper.Map<Company>(request);

            var isAdded = await _generalRepo.AddAsync(company, ct);

            if (!isAdded) return RequestResult<bool>.Failure("Company wasn't added successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isAdded, "Company added successfully!");
        }
    }
}
