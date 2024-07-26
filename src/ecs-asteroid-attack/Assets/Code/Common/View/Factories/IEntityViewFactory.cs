using Entitas;

namespace Code.Common.View.Factories
{
  public interface IEntityViewFactory
  {
    IEntityView CreateViewForEntityFromPath(IEntity entity);
    IEntityView CreateViewForEntityFromPrefab(IEntity entity);
  }
}