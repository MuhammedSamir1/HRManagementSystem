using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models.AddressEntity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CityManagement.AddCity.Commands;


public record AddCityCommand(string Name, int StateId) : IRequest<RequestResult<bool>>;
public sealed class AddCityCommandHandler : RequestHandlerBase<AddCityCommand, RequestResult<bool>, City, int>
{
    public AddCityCommandHandler(RequestHandlerBaseParameters<City, int> parameters) : base(parameters)
    {
    }
    public override async Task<RequestResult<bool>> Handle(AddCityCommand request, CancellationToken ct)
    {
        // تحقق من وجود المدينة بنفس الاسم في نفس الولاية
        var cityExists = await _generalRepo.Get(x => x.Name == request.Name
                                                  && x.StateId == request.StateId
                                                  && !x.IsDeleted, ct)
                                           .AnyAsync(ct);
        if (cityExists)
            return RequestResult<bool>.Failure(
                "City with this name already exists in the selected state.",
                ErrorCode.Conflict);

        // تحويل Command إلى Entity باستخدام AutoMapper
        var city = _mapper.Map<AddCityCommand, City>(request);

        var isAdded = await _generalRepo.AddAsync(city, ct);

        if (!isAdded)
            return RequestResult<bool>.Failure(
                "City wasn't added successfully!",
                ErrorCode.InternalServerError);

        return RequestResult<bool>.Success(isAdded, "City added successfully!");
    }
}


