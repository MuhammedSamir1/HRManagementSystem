using AutoMapper.QueryableExtensions;
using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.BankManagement.GetAllBanks.Queries
{
    public record GetAllBanksQuery() : IRequest<RequestResult<IEnumerable<GetAllBanksDto>>>;

    public class GetAllBanksQueryHandler : RequestHandlerBase<GetAllBanksQuery, RequestResult<IEnumerable<GetAllBanksDto>>, Bank, Guid>
    {
        public GetAllBanksQueryHandler(RequestHandlerBaseParameters<Bank, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<IEnumerable<GetAllBanksDto>>> Handle(GetAllBanksQuery request, CancellationToken ct)
        {
            var banks = await _generalRepo.Get(x => !x.IsDeleted, ct)
               .ProjectTo<GetAllBanksDto>(_mapper.ConfigurationProvider)
               .ToListAsync(ct);

            if (banks is null)
                return RequestResult<IEnumerable<GetAllBanksDto>>.Failure("No banks found.", ErrorCode.NotFound);

            return RequestResult<IEnumerable<GetAllBanksDto>>.Success(banks, "Banks retrieved successfully!");
        }
    }
}


