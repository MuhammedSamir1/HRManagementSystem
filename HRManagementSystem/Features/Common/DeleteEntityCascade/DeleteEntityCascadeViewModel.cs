using FluentValidation;

namespace HRManagementSystem.Features.Common.DeleteEntityCascade;

public sealed record DeleteEntityCascadeViewModel<TEntity, TKey>(int Id);
public class DeleteEntityCascadeViewModelValidator<TEntity, TKey>
  : AbstractValidator<DeleteEntityCascadeViewModel<TEntity, TKey>>
  where TEntity : BaseModel<TKey>
{
    public DeleteEntityCascadeViewModelValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
