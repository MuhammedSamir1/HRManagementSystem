using AutoMapper;
using HRManagementSystem.Data.Models;

namespace HRManagementSystem.Features.CurrencyManagement.GetAllCurrency.Mapping
{
    public class GetAllCurrencyProfile : Profile
    {
        public GetAllCurrencyProfile()
        {
            CreateMap<Currency, GetAllCurrencyDto>();
            CreateMap<GetAllCurrencyDto, GetAllCurrencyResponseViewModel>();
        }
    }
}
