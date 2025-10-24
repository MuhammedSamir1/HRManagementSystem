using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models.AddressEntity;

namespace HRManagementSystem.Features.CountryManagement.DeleteCountry.Commands
{
    public sealed class DeleteCountryCommandHandler : RequestHandlerBase<DeleteCountryCommand, ResponseViewModel<bool>, Country, int>
    {
        public DeleteCountryCommandHandler(RequestHandlerBaseParameters<Country, int> parameters) : base(parameters)
        {
        }

        public override async Task<ResponseViewModel<bool>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            // SoftDeleteAsync يتضمن منطق التحقق من الوجود (IsExistAsync)
            var result = await _generalRepo.SoftDeleteAsync(request.Id, cancellationToken);

            if (!result)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.NotFound);
            }

            return ResponseViewModel<bool>.Success(true, "Country deleted successfully.");
        }
    }
}
