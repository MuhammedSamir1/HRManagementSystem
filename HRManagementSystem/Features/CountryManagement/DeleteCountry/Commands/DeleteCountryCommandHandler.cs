using HRManagementSystem.Data.Models.AddressEntity;

namespace HRManagementSystem.Features.CountryManagement.DeleteCountry.Commands
{
    public sealed class DeleteCountryCommandHandler : RequestHandlerBase<DeleteCountryCommand, RequestResult<bool>, Country, Guid>
    {
        public DeleteCountryCommandHandler(RequestHandlerBaseParameters<Country, Guid> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            // SoftDeleteAsync 
            var result = await _generalRepo.SoftDeleteAsync(request.Id, cancellationToken);

            if (!result)
            {
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            }

            return RequestResult<bool>.Success(true, "Country deleted successfully.");
        }
    }
}

