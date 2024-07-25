using Entitas;

namespace Code.Common.Physics
{
  public interface IColliderToEntityRegistry
  {
    void Register(int instanceId, IEntity entity);
    
    void Unregister(int instanceId);
  }
}