using Entitas;

namespace Code.Common.EntityFactories
{
  public interface IEntityFactory
  {
    TEntity Create<TEntity>() where TEntity : class, IEntity;
  }
}