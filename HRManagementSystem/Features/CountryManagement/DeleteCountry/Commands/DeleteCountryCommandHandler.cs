using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.CityManagement.HasAssignedCities;

namespace HRManagementSystem.Features.CountryManagement.DeleteCountry.Commands
{
    public sealed class DeleteCountryCommandHandler : RequestHandlerBase<DeleteCountryCommand, RequestResult<bool>, Country, int>
    {
        public DeleteCountryCommandHandler(RequestHandlerBaseParameters<Country, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {

            var existingCountry = await _generalRepo.GetByIdAsync(request.Id);
            if (existingCountry == null)
            {

                return RequestResult<bool>.Failure("Country not found or already deleted.", ErrorCode.NotFound);
            }


            var cityCheck = await _mediator.Send(new HasAssignedCitiesQuery(request.Id), cancellationToken);
            if (!cityCheck.isSuccess)
            {

                return RequestResult<bool>.Failure(cityCheck.message, cityCheck.errorCode);
            }


            var result = await _generalRepo.SoftDeleteAsync(request.Id, cancellationToken);

            if (!result)
            {

                return RequestResult<bool>.Failure("Failed to delete the country.", ErrorCode.InternalServerError);
            }

            return RequestResult<bool>.Success(true, "Country deleted successfully.");
        }
    }
}
