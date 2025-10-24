using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.BranchManagement.GetBranchById.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.BranchManagement.GetBranchById
{
    public class GetBranchByIdEndPoint : BaseEndPoint<GetBranchByIdViewModel,
        ResponseViewModel<ViewBranchByIdViewModel>>
    {
        public GetBranchByIdEndPoint(EndPointBaseParameters<GetBranchByIdViewModel> parameters)
            : base(parameters) { }

        [HttpGet("id")]
        public async Task<ResponseViewModel<ViewBranchByIdViewModel>> GetById([FromQuery] GetBranchByIdViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewBranchByIdViewModel>.Failure(validationResult.errorCode);
            }

            var org = await _mediator.Send(new GetBranchByIdQuery(model.Id));

            if (!org.isSuccess) return ResponseViewModel<ViewBranchByIdViewModel>.Failure(org.message,
                ErrorCode.BranchNotFound);

            var vm = _mapper.Map<ViewBranchByIdViewModel>(org.data);
            return ResponseViewModel<ViewBranchByIdViewModel>.Success(vm);
        }
    }

}
