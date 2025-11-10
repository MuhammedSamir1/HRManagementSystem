using HRManagementSystem.Data.Models.AddressEntity;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CityManagement.UpdateCity.Command
{
    public sealed record UpdateCityCommand(int Id, string Name, int StateId) : IRequest<RequestResult<bool>>;

    public sealed class UpdateCityCommandHandler
        : RequestHandlerBase<UpdateCityCommand, RequestResult<bool>, City, int>
    {
        public UpdateCityCommandHandler(RequestHandlerBaseParameters<City, int> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(UpdateCityCommand request, CancellationToken ct)
        {

            var isExist = await _generalRepo.IsExistAsync(request.Id, ct);
            if (!isExist)
                return RequestResult<bool>.Failure("City not found.", ErrorCode.NotFound);

            // No Dublation
            var nameExists = await _generalRepo
                .Get(x => x.Name == request.Name && x.Id != request.Id && !x.IsDeleted, ct)
                .AnyAsync(ct);

            if (nameExists)
                return RequestResult<bool>.Failure("City name already exists.", ErrorCode.Conflict);

            // Updating
            var city = _mapper.Map<UpdateCityCommand, City>(request);
            var isUpdated = await _generalRepo.UpdateAsync(city, ct);

            if (!isUpdated)
                return RequestResult<bool>.Failure("City wasn't updated successfully!", ErrorCode.InternalServerError);

            return RequestResult<bool>.Success(true, "City updated successfully!");
        }
    }
}



//isex