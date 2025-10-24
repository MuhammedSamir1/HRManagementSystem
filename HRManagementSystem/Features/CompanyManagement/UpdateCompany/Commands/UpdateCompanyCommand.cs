using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.Common.CompanyCommon.IsCompanyExist.Queries;
using MediatR;

namespace HRManagementSystem.Features.CompanyManagement.UpdateCompany.Commands
{
    public record UpdateCompanyCommand(int id, string name, string? description)
        : IRequest<RequestResult<bool>>;


    public class UpdateCompanyCommandHandler : RequestHandlerBase<UpdateCompanyCommand, RequestResult<bool>, Company, int>
    {
        public UpdateCompanyCommandHandler(RequestHandlerBaseParameters<Company, int> parameters) : base(parameters)
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
