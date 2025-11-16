using HRManagementSystem.Data.Models.AddressEntity;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CityManagement.AddCity.Commands;


public record AddCityCommand(string Name, Guid StateId) : IRequest<RequestResult<bool>>;
public sealed class AddCityCommandHandler : RequestHandlerBase<AddCityCommand, RequestResult<bool>, City, Guid>
{
    public AddCityCommandHandler(RequestHandlerBaseParameters<City, Guid> parameters) : base(parameters)
    {
    }
    public override async Task<RequestResult<bool>> Handle(AddCityCommand request, CancellationToken ct)
    {
        // ???? ?? ???? ??????? ???? ????? ?? ??? ???????
        var cityExists = await _generalRepo.Get(x => x.Name == request.Name
                                                  && x.StateId == request.StateId
                                                  && !x.IsDeleted, ct)
                                           .AnyAsync(ct);
        if (cityExists)
            return RequestResult<bool>.Failure(
                "City with this name already exists in the selected state.",
                ErrorCode.Conflict);

        // ????? Command ??? Entity ???????? AutoMapper
        var city = _mapper.Map<AddCityCommand, City>(request);

        var isAdded = await _generalRepo.AddAsync(city, ct);

        if (!isAdded)
            return RequestResult<bool>.Failure(
                "City wasn't added successfully!",
                ErrorCode.InternalServerError);

        return RequestResult<bool>.Success(isAdded, "City added successfully!");
    }
}



