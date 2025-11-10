using FluentValidation;

namespace HRManagementSystem.Features.CustodyManagement.DeleteCustody.Commands
{
    public sealed record DeleteCustodyCommand(int Id) : IRequest<RequestResult<bool>>;

    public class DeleteCustodyCommandValidator : AbstractValidator<DeleteCustodyCommand>
    {
        public DeleteCustodyCommandValidator()
        {
      
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("معرّف العهدة غير صالح للحذف.");
        }
    }
}
