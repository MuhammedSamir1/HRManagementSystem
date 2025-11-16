namespace HRManagementSystem.Features.Common.DeleteEntityCascade.Command
{

    public sealed record DeleteEntityCascadeCommand<TEntity, TKey>(Guid Id) : IRequest<RequestResult<bool>>;
}

