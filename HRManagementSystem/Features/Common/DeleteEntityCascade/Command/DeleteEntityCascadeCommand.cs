namespace HRManagementSystem.Features.Common.DeleteCascadeGeneric
{

    public sealed record DeleteEntityCascadeCommand<TEntity, TKey>(int Id) : IRequest<RequestResult<bool>>;
}
