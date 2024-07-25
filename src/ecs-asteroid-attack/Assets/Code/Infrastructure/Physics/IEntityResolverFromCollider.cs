namespace Code.Common.Physics
{
  public interface IEntityResolverFromCollider
  {
    TEntity Resolve<TEntity>(int instanceId) where TEntity : class;
  }
}