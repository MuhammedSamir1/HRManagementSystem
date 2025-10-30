using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.ViewModels;

namespace HRManagementSystem.Features.Common.AddressManagement.StateCommon
{
    public sealed class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, ViewStateDto>();

            CreateMap<ViewStateDto, ViewStateViewModel>().ReverseMap();
        }
    }
}
