using FluentValidation;

namespace HRManagementSystem.Features.Common.DeleteEntityCascade;

public sealed record DeleteEntityCascadeViewModel<TEntity, TKey>(TKey Id);
public class DeleteEntityCascadeViewModelValidator<TEntity, TKey>
  : AbstractValidator<DeleteEntityCascadeViewModel<TEntity, TKey>>
  where TEntity : BaseModel<TKey>
  where TKey : struct
{
    public DeleteEntityCascadeViewModelValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id is required.")
            .NotEqual(default(TKey)).WithMessage("Id must not be empty.");
    }
}
