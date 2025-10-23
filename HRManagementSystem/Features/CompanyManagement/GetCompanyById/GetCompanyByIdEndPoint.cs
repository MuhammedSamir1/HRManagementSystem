using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.CompanyManagement.GetCompanyById.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.CompanyManagement.GetCompanyById
{
    public class GetCompanyByIdEndPoint : BaseEndPoint<GetCompanyByIdRequestViewModel, ResponseViewModel<GetCompanyByIdResponseViewModel>>
    {
        public GetCompanyByIdEndPoint(EndPointBaseParameters<GetCompanyByIdRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet("GetCompanyById")]
        public async Task<ResponseViewModel<GetCompanyByIdResponseViewModel>> GetCompanyById([FromQuery] GetCompanyByIdRequestViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<GetCompanyByIdResponseViewModel>.Failure(validationResult.errorCode);

            var result = await _mediator.Send(new GetCompanyByIdQuery(model.companyId));

            if (!result.isSuccess || result.data is null)
                return ResponseViewModel<GetCompanyByIdResponseViewModel>.Failure(ErrorCode.NotFound);

            var mappedCompany = _mapper.Map<GetCompanyByIdResponseViewModel>(result.data);

            return ResponseViewModel<GetCompanyByIdResponseViewModel>.Success(mappedCompany, "Company returned Successfully!");
        }

    }
}
