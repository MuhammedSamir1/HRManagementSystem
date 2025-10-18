using AutoMapper;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.Common.CurrencyManagement.ViewModels;

namespace HRManagementSystem.Features.Common.CurrencyManagement
{
    public sealed class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<AddOrganizationCurrencyDto, Currency>()
           .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<AddOrganizationCurrencyDto, AddOrganizationCurrencyViewModel>().ReverseMap();
        }
    }
}
