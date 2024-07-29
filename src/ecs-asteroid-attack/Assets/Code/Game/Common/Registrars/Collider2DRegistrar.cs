using Code.Common.View.Registrars;
using UnityEngine;

namespace Code.Game.Common.Registrars
{
  public class Collider2DRegistrar : EntityComponentRegistrar<GameEntity>
  {
    [SerializeField] private Collider2D _collider;

    public override void Register(GameEntity entity)
    {
      if (_collider == null) _collider = GetComponent<Collider2D>();
      if (_collider != null) entity.AddCollider2D(_collider);
    }

    public override void Unregister(GameEntity entity)
    {
      if (entity.hasCollider2D)
        entity.RemoveCollider2D();
    }
  }
}