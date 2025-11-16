using HRManagementSystem.Features.Common.CompanyCommon.IsCompanyExist.Queries;

namespace HRManagementSystem.Features.CompanyManagement.UpdateCompany.Commands
{
    public record UpdateCompanyCommand(Guid id, string name, string? description)
        : IRequest<RequestResult<bool>>;


    public class UpdateCompanyCommandHandler : RequestHandlerBase<UpdateCompanyCommand, RequestResult<bool>, Company, Guid>
    {
        public UpdateCompanyCommandHandler(RequestHandlerBaseParameters<Company, Guid> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(UpdateCompanyCommand request, CancellationToken ct)
        {
            var isExist = await _mediator.Send(new IsCompanyExistQuery(request.id));
            if (!isExist.isSuccess) return RequestResult<bool>.Failure("Company not found.", ErrorCode.NotFound);

            var company = _mapper.Map<UpdateCompanyCommand, Company>(request);
            var isUpdated = await _generalRepo.UpdateAsync(company, ct);

            if (!isUpdated) return RequestResult<bool>.Failure("Company wasn't Updated successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isUpdated, "Company Updated successfully!");
        }
    }
}

