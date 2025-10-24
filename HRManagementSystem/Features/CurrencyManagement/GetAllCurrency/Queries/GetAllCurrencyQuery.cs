using AutoMapper.QueryableExtensions;
using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CurrencyManagement.GetAllCurrency.Queries
{
    public record GetAllCurrencyQuery() : IRequest<RequestResult<IEnumerable<GetAllCurrencyDto>>>;

    public sealed class GetAllCurrencyQueryHandler : RequestHandlerBase<GetAllCurrencyQuery, RequestResult<IEnumerable<GetAllCurrencyDto>>, Currency, int>
    {
        public GetAllCurrencyQueryHandler(RequestHandlerBaseParameters<Currency, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<IEnumerable<GetAllCurrencyDto>>> Handle(GetAllCurrencyQuery request, CancellationToken ct)
        {
            var companiesDto = await _generalRepo.GetAll()
                            .ProjectTo<GetAllCurrencyDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(ct);

            if (!companiesDto.Any())
                return RequestResult<IEnumerable<GetAllCurrencyDto>>.Failure("No companies!", ErrorCode.NotFound);

            return RequestResult<IEnumerable<GetAllCurrencyDto>>.Success(companiesDto, "Companies returned successfully!");
        }
    }
}
