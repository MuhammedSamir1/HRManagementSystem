using HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.ViewModels;
using HRManagementSystem.Features.Common.CurrencyManagement.GetCurrencyDtosAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.GetCurrencyDtosAndVms.ViewModels;
using HRManagementSystem.Features.Common.CurrencyManagement.UpdateCurrencyDtosAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.UpdateCurrencyDtosAndVms.ViewModels;

namespace HRManagementSystem.Features.Common.CurrencyManagement
{
    public sealed class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<AddOrganizationCurrencyDto, Currency>()
           .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<UpdateOrganizationCurrencyDto, Currency>()
           .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<Currency, ViewOrganizationCurrencyDto>();

            CreateMap<AddOrganizationCurrencyDto, AddOrganizationCurrencyViewModel>().ReverseMap();
            CreateMap<UpdateOrganizationCurrencyDto, UpdateOrganizationCurrencyViewModel>().ReverseMap();
            CreateMap<ViewOrganizationCurrencyDto, ViewOrganizationCurrencyViewModel>().ReverseMap();
        }
    }
}
