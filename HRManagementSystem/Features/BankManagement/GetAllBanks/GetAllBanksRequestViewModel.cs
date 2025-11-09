using FluentValidation;

namespace HRManagementSystem.Features.BankManagement.GetAllBanks
{
    public record GetAllBanksRequestViewModel();

    public class GetAllBanksRequestViewModelValidator : AbstractValidator<GetAllBanksRequestViewModel>
    {
        public GetAllBanksRequestViewModelValidator()
        {
        }
    }
}

