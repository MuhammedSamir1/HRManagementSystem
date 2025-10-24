using AutoMapper;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.CurrencyManagement.AddCurrency.Commands;

namespace HRManagementSystem.Features.CurrencyManagement.AddCurrency.Mapping
{
    public class AddCurrencyProfile : Profile
    {
        public AddCurrencyProfile()
        {
            CreateMap<AddCurrencyCommand, Currency>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.NumericCode, opt => opt.MapFrom(src => src.NumericCode))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.Symbol));
        }
    }
}
