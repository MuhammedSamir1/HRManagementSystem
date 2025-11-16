using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.AddCustody
{
    public record AddCustodyViewModel(
     string ItemName,
     string SerialNumber,
     DateTime HandoverDate);
    public class AddCustodyCommandValidator : AbstractValidator<AddCustodyViewModel>
    {
        public AddCustodyCommandValidator()
        {
            RuleFor(x => x.ItemName).NotEmpty().WithMessage("??? ?????? ?????.").MaximumLength(250);
            RuleFor(x => x.SerialNumber).NotEmpty().WithMessage("????? ???????? ?????.").MaximumLength(150);
            RuleFor(x => x.HandoverDate).LessThanOrEqualTo(DateTime.Today).WithMessage("????? ??????? ?? ???? ?? ???? ?? ????????.");
        }
    }
}


