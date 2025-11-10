namespace HRManagementSystem.Features.Common.DeleteEntityCascade.Command
{

    public sealed record DeleteEntityCascadeCommand<TEntity, TKey>(int Id) : IRequest<RequestResult<bool>>;
}
