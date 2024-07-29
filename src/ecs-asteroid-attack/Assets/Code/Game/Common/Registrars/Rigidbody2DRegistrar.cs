using Code.Common.View.Registrars;
using UnityEngine;

namespace Code.Game.Common.Registrars
{
  public class Rigidbody2DRegistrar : EntityComponentRegistrar<GameEntity>
  {
    [SerializeField] private Rigidbody2D _rigidbody;

    public override void Register(GameEntity entity)
    {
      if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody2D>();
      if (_rigidbody != null) entity.AddRigidbody2D(_rigidbody);
    }

    public override void Unregister(GameEntity entity)
    {
      if (entity.hasRigidbody2D)
        entity.RemoveRigidbody2D();
    }
  }
}