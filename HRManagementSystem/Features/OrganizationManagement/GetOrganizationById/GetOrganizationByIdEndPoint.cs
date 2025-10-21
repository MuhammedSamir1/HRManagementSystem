using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.OrganizationManagement.GetOrganizationById.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.OrganizationManagement.GetOrganizationById
{
    public class GetOrganizationByIdEndPoint : BaseEndPoint<GetOrganizationByIdViewModel,
        ResponseViewModel<ViewOrganizationViewModel>>
    {
        public GetOrganizationByIdEndPoint(EndPointBaseParameters<GetOrganizationByIdViewModel> parameters)
            : base(parameters) { }

        [HttpGet("id")]
        public async Task<ResponseViewModel<ViewOrganizationViewModel>> GetById([FromQuery] GetOrganizationByIdViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewOrganizationViewModel>.Failure(validationResult.errorCode);
            }

            var org = await _mediator.Send(new GetOrganizationByIdQuery(model.Id));

            if (!org.isSuccess) return ResponseViewModel<ViewOrganizationViewModel>.Failure(org.message,
                ErrorCode.OrganizationNotFound);

            var vm = _mapper.Map<ViewOrganizationViewModel>(org.data);
            return ResponseViewModel<ViewOrganizationViewModel>.Success(vm);
        }
    }
}
