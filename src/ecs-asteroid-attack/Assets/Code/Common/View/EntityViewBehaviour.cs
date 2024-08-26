using Code.Common.View.Registrars;
using Code.Infrastructure.Physics;
using Entitas;
using UnityEngine;
using VContainer;

namespace Code.Common.View
{
  public class EntityViewBehaviour : MonoBehaviour, IEntityView
  {
    private IEntity _entity;
    private IColliderToEntityRegistry _colliderRegistry;

    public string PoolKey { get; set; }
    
    public GameObject GameObject => gameObject;
    
    [Inject]
    public void Construct(IColliderToEntityRegistry colliderRegistry)
    {
      _colliderRegistry = colliderRegistry;
    }
    
    public void Retain(IEntity entity)
    {
      _entity = entity;
      _entity.AddComponent(new ViewComponent { Value = this });
      _entity.Retain(this);

      foreach (IEntityComponentRegistrar registrar in gameObject.GetComponentsInChildren<IEntityComponentRegistrar>(true))
        registrar.Register(_entity);
      
      foreach (Collider2D collider2d in gameObject.GetComponentsInChildren<Collider2D>(true))
        _colliderRegistry.Register(collider2d.GetInstanceID(), _entity);
    }

    public void Release()
    {
      foreach (IEntityComponentRegistrar registrar in gameObject.GetComponentsInChildren<IEntityComponentRegistrar>(true))
        registrar.Unregister(_entity);
      
      foreach (Collider2D collider2d in gameObject.GetComponentsInChildren<Collider2D>(true))
        _colliderRegistry.Unregister(collider2d.GetInstanceID());
      
      _entity.Release(this);
      _entity = null;
    }
  }
}